// Приведенный ниже блок ifdef — это стандартный метод создания макросов, упрощающий процедуру
// экспорта из библиотек DLL. Все файлы данной DLL скомпилированы с использованием символа DLLVISUALCPP_EXPORTS
// Символ, определенный в командной строке. Этот символ не должен быть определен в каком-либо проекте,
// использующем данную DLL. Благодаря этому любой другой проект, исходные файлы которого включают данный файл, видит
// функции DLLVISUALCPP_API как импортированные из DLL, тогда как данная DLL видит символы,
// определяемые данным макросом, как экспортированные.
#ifdef DLLVISUALCPP_EXPORTS
#define DLLVISUALCPP_API __declspec(dllexport)
#else
#define DLLVISUALCPP_API __declspec(dllimport)
#endif

DLLVISUALCPP_API double GetRangeValueFromVector(far double* array, int size);
DLLVISUALCPP_API double GetAverageValueFromVector(far double* array, int size);
DLLVISUALCPP_API double GetAverageValueFromMatrix(far double** matrix, int size);
