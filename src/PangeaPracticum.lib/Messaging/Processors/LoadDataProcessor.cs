using PangeaPracticum.lib.Messaging.Messages;

namespace PangeaPracticum.lib.Messaging.Processors
{
    public class LoadDataProcessor : IBusMessageProcessor<LoadDataRequest>
    {
        IRepoLoader _repoLoader;
        IRepositoryService _repositoryService;

        public LoadDataProcessor(IRepoLoader repoLoader, IRepositoryService repositoryService)
        {
            _repoLoader = repoLoader;
            _repositoryService = repositoryService;
        }

        public void Process(LoadDataRequest msg)
        {
            var repos = _repoLoader.LoadRepos();
            _repositoryService.SaveAll(repos);
        }
    }
}
