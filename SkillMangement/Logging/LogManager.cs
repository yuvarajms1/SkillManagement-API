namespace SkillMangement.API.Logging
{
    public static class LogManager
    {
        private static ILoggerFactory _loggerFactory;

        public static void Setup(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
        }

        public static ILogger CreateLogger(string typeName)
        {
            return _loggerFactory.CreateLogger(typeName);
        }
    }
}
