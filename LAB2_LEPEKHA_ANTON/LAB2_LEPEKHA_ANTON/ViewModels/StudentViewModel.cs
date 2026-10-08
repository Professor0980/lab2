using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using LAB2_LEPEKHA_ANTON.Models;

namespace LAB2_LEPEKHA_ANTON.ViewModels;

public class StudentViewModel : IQueryAttributable, INotifyPropertyChanged
{
    public ObservableCollection<Student> Students { get; set; }
    public ICommand OpenDetailsCommand { get; set; }

    public StudentViewModel()
    {
        Students = new ObservableCollection<Student>
        {
            new Student { Id = 1, FullName = "Жмишенко Валерій Альбертович", Group = "фіт0-1", AverageScore = 4.5 },
            new Student { Id = 2, FullName = "Микола Парасюк", Group = "фіт0-2", AverageScore = 3.8 },
            new Student { Id = 3, FullName = "Жма Антон Павлович", Group = "фіт0-3", AverageScore = 4.9 }
        };

        OpenDetailsCommand = new Command<Student>(async (student) =>
        {
            if (student == null) return;

            var parameters = new Dictionary<string, object>
            {
                { "SelectedStudent", student }
            };

            await Shell.Current.GoToAsync("studentdetail", parameters);
        });
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.TryGetValue("UpdatedStudent", out var value) && value is Student updatedStudent)
        {
            for (int i = 0; i < Students.Count; i++)
            {
                if (Students[i].Id == updatedStudent.Id)
                {
                    Students[i] = updatedStudent;
                    break;
                }
            }
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    public void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}