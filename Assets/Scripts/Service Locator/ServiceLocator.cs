//Нужен для работы с типами: typeof(AudioService), typeof(SaveService) и т.д.
using System;
//Нужен для Dictionary — словаря, в котором мы будем хранить наши сервисы
using System.Collections.Generic;


//static означает, что нам не нужно создавать объект ServiceLocator: new ServiceLocator();
// Мы будем обращаться к нему напрямую:
// ServiceLocator.Register(...)
// ServiceLocator.Get(...)
public static class ServiceLocator
{
    // Dictionary — это коллекция "ключ → значение".
    //
    // В нашем случае:
    //
    // Type   →  object
    //
    // Например:
    //
    // typeof(AudioService) → экземпляр AudioService
    // typeof(SaveService)  → экземпляр SaveService
    //
    // То есть здесь фактически будет храниться:
    //
    // AudioService    → ссылка на AudioService
    // SaveService     → ссылка на SaveService
    //
    // static означает, что этот словарь существует в одном экземпляре и доступен через сам класс ServiceLocator.

    private static readonly Dictionary<Type, object> services = new();


    // REGISTER

    // Этот метод используется для регистрации сервиса.
    //
    // Например:
    //
    // ServiceLocator.Register(this);
    //
    // Если this — это AudioService, то метод сохранит
    // экземпляр AudioService внутри Dictionary.
    //
    // <T> означает, что метод является generic-методом.
    //
    // Если передали AudioService:
    //
    // Register<AudioService>(audioService)
    //
    // Если передали SaveService:
    //
    // Register<SaveService>(saveService)
    public static void Register<T>(T service)
    {
        // typeof(T) получает информацию о типе T.
        // Например, если T = AudioService: typeof(T) превращается в: typeof(AudioService)
        // После этого мы сохраняем сервис в Dictionary.
        // Получается примерно: services[ typeof(AudioService) ] = audioService;
        services[typeof(T)] = service;
    }

    // GET
    //
    // Этот метод нужен, чтобы получить ранее зарегистрированный
    // сервис.
    //
    // Например:
    //
    // AudioService audio =
    //     ServiceLocator.Get<AudioService>();
    //
    // Метод найдёт AudioService в Dictionary
    // и вернёт его.
    public static T Get<T>()
    {
        // TryGetValue пытается найти значение в Dictionary.
        //
        // Первый параметр:
        //
        // typeof(T)
        //
        // говорит:
        //
        // "Найди сервис такого типа".
        //
        // Второй параметр:
        //
        // out object service
        //
        // получит найденный объект.
        //
        // Если сервис существует:
        //
        // found = true
        //
        // Если сервиса нет:
        //
        // found = false
        if (!services.TryGetValue(typeof(T), out object service))
        {
            // Если сюда попали, значит мы попросили сервис,
            // который никто ещё не зарегистрировал.
            //
            // Например:
            //
            // ServiceLocator.Get<AudioService>();
            //
            // но AudioService нигде не сделал:
            //
            // ServiceLocator.Register(this);
            //
            // Тогда выбрасываем понятную ошибку.
            throw new Exception(
                $"Service {typeof(T).Name} is not registered."
            );
        }

        // Здесь service имеет тип object.
        //
        // Но мы знаем, что внутри лежит именно T.
        //
        // Поэтому приводим object обратно к T.
        //
        // Например:
        //
        // object → AudioService
        //
        // или:
        //
        // object → SaveService
        return (T)service;
    }

    // TRY GET
    //
    // Это альтернативный способ получить сервис.
    //
    // Разница с Get:
    //
    // Get выбрасывает ошибку, если сервиса нет.
    //
    // TryGet просто говорит:
    //
    // "Нашёл" или "не нашёл".
    //
    // Пример:
    //
    // if (ServiceLocator.TryGet<AudioService>(out var audio))
    // {
    //     audio.PlaySound();
    // }
    public static bool TryGet<T>(out T service)
    {
        // Пытаемся найти сервис.
        if (services.TryGetValue(typeof(T), out object value))
        {
            // Если нашли — преобразуем object в T.
            service = (T)value;

            // true означает:
            // "Сервис найден".
            return true;
        }

        // Если сервис не найден,
        // возвращаем стандартное значение для T.
        //
        // Для классов это будет null.
        service = default;

        // false означает:
        // "Сервис не найден".
        return false;
    }

    // UNREGISTER
    //
    // Этот метод удаляет сервис из ServiceLocator.
    //
    // Например:
    //
    // ServiceLocator.Unregister<AudioService>();
    //
    // После этого:
    //
    // ServiceLocator.Get<AudioService>();
    //
    // больше не сможет его получить.
    public static void Unregister<T>()
    {
        // Remove удаляет элемент из Dictionary
        // по указанному ключу.
        services.Remove(typeof(T));
    }


    // CLEAR
    //
    // Полностью очищает ServiceLocator.
    //
    // Например, это может пригодиться при перезапуске игры,
    // во время тестирования или при специальной инициализации.
    public static void Clear()
    {
        // Удаляем все зарегистрированные сервисы.
        services.Clear();
    }
}