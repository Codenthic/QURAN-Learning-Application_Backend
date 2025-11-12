using CommunityToolkit.Mvvm.Input;
using QuranJourney.Models;

namespace QuranJourney.PageModels
{
    public interface IProjectTaskPageModel
    {
        IAsyncRelayCommand<ProjectTask> NavigateToTaskCommand { get; }
        bool IsBusy { get; }
    }
}