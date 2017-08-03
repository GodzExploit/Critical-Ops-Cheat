#include <Windows.h>
#include <Shlwapi.h>
#include <tchar.h>
#include <mono/jit/jit.h>
#include <fstream>

// Mono DLL module
HMODULE hMono = GetModuleHandleA("mono.dll");

// Get mono function by name
DWORD GetMonoFunction(char* funcname) {
	return (DWORD)GetProcAddress(hMono, funcname);
}

// Function to invoke a dll method in a mono application
void InjectMono(const char *_dll, const char *_namespace, const char *_class, const char *_method, int paramCount) {
	//Attach
	typedef MonoThread* (__cdecl* mono_thread_attach_t)(MonoDomain* mDomain);
	mono_thread_attach_t mono_thread_attach = (mono_thread_attach_t)GetMonoFunction((char *)"mono_thread_attach");

	//Class
	typedef MonoClass* (__cdecl* mono_class_from_name_t)(MonoImage* image, const char* name_space, const char* name);
	typedef MonoMethod* (__cdecl* mono_class_get_method_from_name_t)(MonoClass* mclass, const char* name, int param_count);
	mono_class_from_name_t mono_class_from_name = (mono_class_from_name_t)GetMonoFunction((char *)"mono_class_from_name");
	mono_class_get_method_from_name_t mono_class_get_method_from_name = (mono_class_get_method_from_name_t)GetMonoFunction((char *)"mono_class_get_method_from_name");

	//Code execution
	typedef MonoObject* (__cdecl* mono_runtime_invoke_t)(MonoMethod* method, void* obj, void** params, MonoObject** exc);
	mono_runtime_invoke_t mono_runtime_invoke = (mono_runtime_invoke_t)GetMonoFunction((char *)"mono_runtime_invoke");

	//Assembly
	typedef MonoAssembly* (__cdecl* mono_assembly_open_t)(MonoDomain* mDomain, const char* filepath);
	typedef MonoImage* (__cdecl* mono_assembly_get_image_t)(MonoAssembly *assembly);
	mono_assembly_open_t mono_assembly_open_ = (mono_assembly_open_t)GetMonoFunction((char *)"mono_domain_assembly_open");
	mono_assembly_get_image_t mono_assembly_get_image_ = (mono_assembly_get_image_t)GetMonoFunction((char *)"mono_assembly_get_image");

	//Domain
	typedef MonoDomain* (__cdecl* mono_root_domain_get_t)();
	typedef MonoDomain* (__cdecl* mono_domain_get_t)();
	mono_root_domain_get_t mono_root_domain_get = (mono_root_domain_get_t)GetMonoFunction((char *)"mono_get_root_domain");
	mono_domain_get_t mono_domain_getnormal = (mono_domain_get_t)GetMonoFunction((char *)"mono_domain_get");

	//No clue what happens here, but is required in order for the domain to be ready at time for code-execution.
	mono_thread_attach(mono_root_domain_get());
	//Now that we're attached we get the domain we are in.
	MonoDomain* domain = mono_domain_getnormal();
	//Opening a custom assembly in the domain.
	MonoAssembly* domainassembly = mono_assembly_open_(domain, _dll);
	//Getting the assembly's Image(Binary image, essentially a file-module).
	MonoImage* Image = mono_assembly_get_image_(domainassembly);
	//Declaring the class inside the custom assembly we're going to use. (Image, NameSpace, ClassName)
	MonoClass* pClass = mono_class_from_name(Image, _namespace, _class);
	//Declaring the method, that attaches our assembly to the game. (Class, MethodName, Parameters)
	MonoMethod* MonoClassMethod = mono_class_get_method_from_name(pClass, _method, paramCount);
	//Invoking said method.
	mono_runtime_invoke(MonoClassMethod, NULL, NULL, NULL);
}

std::string ExePath() {
    char buffer[MAX_PATH];
    GetModuleFileName( NULL, buffer, MAX_PATH );
    std::string::size_type pos = std::string( buffer ).find_last_of( "\\/" );
    return std::string( buffer ).substr( 0, pos);
}

DWORD WINAPI LoopFunction(LPVOID lpParam)
{
    std::string filename = ExePath() + "\\dll.txt";
    std::string dllLocation = "";
    std::ifstream file(filename.c_str());
    getline(file, dllLocation);
    file.close();

    InjectMono(dllLocation.c_str(), "UnityGameObject", "Loader", "Load", 0);
    return 0;
}

BOOL WINAPI DllMain(HINSTANCE hinstDLL, DWORD fdwReason, LPVOID lpvReserved)
{
	if (fdwReason == DLL_PROCESS_ATTACH)
		CreateThread(NULL, 0, &LoopFunction, NULL, 0, NULL);

    return TRUE; // successful
}

/*
    switch (fdwReason)
    {
        case DLL_PROCESS_ATTACH:
            // attach to process
            // return FALSE to fail DLL load
            break;

        case DLL_PROCESS_DETACH:
            // detach from process
            break;

        case DLL_THREAD_ATTACH:
            // attach to thread
            break;

        case DLL_THREAD_DETACH:
            // detach from thread
            break;
    }
*/
