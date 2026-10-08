using System.ComponentModel;
using System.Windows.Input;
using LAB2_LEPEKHA_ANTON.Models;

namespace LAB2_LEPEKHA_ANTON.ViewModels;

public class StudentDetailViewModel : IQueryAttributable, INotifyPropertyChanged
{
    private Student? originalStudent;

    public string FullName { get; set; } = string.Empty;
    public string Group { get; set; } = string.Empty;
    public double AverageScore { get; set; }

    public ICommand GoBackCommand { get; set; }
    public ICommand SaveCommand { get; set; }

    public StudentDetailViewModel()
    {
        GoBackCommand = new Command(async () =>
        {
            await Shell.Current.GoToAsync("..");
        });

        SaveCommand = new Command(async () =>
        {
            if (originalStudent != null)
            {
                originalStudent.AverageScore = AverageScore;

                var parameters = new Dictionary<string, object>
                {
                    { "UpdatedStudent", originalStudent }
                };

                await Shell.Current.GoToAsync("..", parameters);
            }
        });
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.TryGetValue("SelectedStudent", out var value) && value is Student student)
        {
            originalStudent = student;
            FullName = student.FullName;
            Group = student.Group;
            AverageScore = student.AverageScore;

            OnPropertyChanged(nameof(FullName));
            OnPropertyChanged(nameof(Group));
            OnPropertyChanged(nameof(AverageScore));
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    public void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}