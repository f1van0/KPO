// Приведенный ниже блок ifdef — это стандартный метод создания макросов, упрощающий процедуру
// экспорта из библиотек DLL. Все файлы данной DLL скомпилированы с использованием символа DLLCONTRAST_EXPORTS
// Символ, определенный в командной строке. Этот символ не должен быть определен в каком-либо проекте,
// использующем данную DLL. Благодаря этому любой другой проект, исходные файлы которого включают данный файл, видит
// функции DLLCONTRAST_API как импортированные из DLL, тогда как данная DLL видит символы,
// определяемые данным макросом, как экспортированные.
#ifdef DLLCONTRAST_EXPORTS
#define DLLEXPORT __declspec(dllexport)
#else
#define DLLCONTRAST_API __declspec(dllimport)
#endif

DLLEXPORT const char* getInfo();
DLLEXPORT BYTE* filterFunct(BYTE* array, int length);
