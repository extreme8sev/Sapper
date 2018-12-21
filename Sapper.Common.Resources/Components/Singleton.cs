namespace Sapper.Common.Resources.Components
{
    public class Singleton<T>
        where T : class, new()

    {
        private static T _instance;

        private Singleton()
        {
        }

        public static T Instance => _instance ?? (_instance = new T());
    }
}