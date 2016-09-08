using Measurement.Repositories;

namespace Measurement.Providers.JsonProviders
{
    public abstract class BaseJsonFileProvider
    {
        #region Private

        protected readonly string filePath;

        protected IFileRepository fileRepository;

        #endregion

        #region Ctors

        public BaseJsonFileProvider(string filePath)
        {
            this.filePath = filePath;
        }

        #endregion
    }
}
