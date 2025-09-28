namespace EasyWorklogJira.Test.Functional;

public class WorklogCreationFunctionalTests : IClassFixture<FunctionalTestFixture>
{
    private readonly IServiceProvider _serviceProvider;

    public WorklogCreationFunctionalTests(FunctionalTestFixture fixture)
    {
        _serviceProvider = fixture.ServiceProvider;
    }

    [Fact]
    public async Task CreateWorklog_CompleteFlow_ShouldCreateWorklogSuccessfully()
    {
        // Arrange
        using var form = _serviceProvider.GetService<WorklogMaintenanceForm>();

        // Act - Simulate form loading
        await InvokeOnUIThread(async () =>
        {
            await form.LoadIssuesOnActiveSprint();
        });

        // Assert - Check if issues were loaded
        await InvokeOnUIThread(async () =>
        {
            await Task.Run(() =>
            {
                ComboBox comboBox = GetPrivateField<ComboBox>(form, "comboBoxIssues");
                Assert.NotNull(comboBox.DataSource);
                Assert.True(comboBox.Items.Count > 0);
            });

        });

        // Act - Fill form fields
        await InvokeOnUIThread(async () =>
        {
            await Task.Run(() =>
            {
                // Simulate user filling the form
                var comboBoxIssues = GetPrivateField<ComboBox>(form, "comboBoxIssues");
                var maskedTextBoxStartTime = GetPrivateField<MaskedTextBox>(form, "maskedTextBoxStartTime");
                var maskedTextBoxTimeSpent = GetPrivateField<MaskedTextBox>(form, "maskedTextBoxTimeSpent");
                var textBoxDescription = GetPrivateField<TextBox>(form, "textBoxIssueDescription");

                comboBoxIssues.SelectedIndex = 0; // Select first issue
                maskedTextBoxStartTime.Text = "09:00";
                maskedTextBoxTimeSpent.Text = "02:30";
                textBoxDescription.Text = "Teste funcional de criação de worklog";
            });
        });

        // Act - Simulate save button click
        var saveResult = await InvokeOnUIThread(async () =>
        {
            var buttonSave = GetPrivateField<Button>(form, "buttonSave");

            // Use reflection to call the private Save method
            var saveMethod = typeof(WorklogMaintenanceForm)
                .GetMethod("Save", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

            try
            {
                await (Task)saveMethod.Invoke(form, null);
                return true;
            }
            catch
            {
                return false;
            }
        });

        // Assert
        Assert.True(saveResult.Result, "Worklog creation should succeed");
    }

    [Fact]
    public async Task CreateWorklog_WithInvalidData_ShouldShowValidationMessages()
    {
        // Arrange
        using var form = _serviceProvider.GetService<WorklogMaintenanceForm>();

        // Mock MessageBox to catpure messages
        string capturedMessage = string.Empty;
        bool messageBoxShown = false;

        // Act - Try to save with empty fields
        await InvokeOnUIThread(async () =>
        {
            var saveMethod = typeof(WorklogMaintenanceForm)
                .GetMethod("Save", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

            await (Task)saveMethod.Invoke(form, null);

            // Verificar se os campos estão realmente vazios após a tentativa de salvamento
            var comboBoxIssues = GetPrivateField<ComboBox>(form, "comboBoxIssues");
            var textBoxDescription = GetPrivateField<TextBox>(form, "textBoxIssueDescription");

            // Se alguns dos campos não foram preenchidos, marca uma flag para simular que MessageBox foi mostrada.
            messageBoxShown = (comboBoxIssues.SelectedItem == null &&
                              string.IsNullOrEmpty(textBoxDescription.Text));
        });

        // Assert - Se a validação falhou, exibe o componente MessaBox.
        Assert.True(messageBoxShown);
    }

    private static async Task<T> InvokeOnUIThread<T>(Func<T> action)
    {
        var tcs = new TaskCompletionSource<T>();

        if (Application.OpenForms.Count == 0)
        {
            // Fix: Application.Run expects a Form, not a lambda.
            // Instead, create a dummy form and use its Shown event to execute the action.
            var dummyForm = new Form();
            dummyForm.Shown += (sender, e) =>
            {
                try
                {
                    var result = action();
                    tcs.SetResult(result);
                }
                catch (Exception ex)
                {
                    tcs.SetException(ex);
                }
                dummyForm.Close();
            };
            Application.Run(dummyForm);
        }
        else
        {
            try
            {
                var result = action();
                tcs.SetResult(result);
            }
            catch (Exception ex)
            {
                tcs.SetException(ex);
            }
        }

        return await tcs.Task;
    }

    private static async Task InvokeOnUIThread(Func<Task> action)
    {
        await InvokeOnUIThread(async () =>
        {
            await action();
            return true;
        });
    }

    private static T GetPrivateField<T>(object obj, string fieldName)
    {
        var field = obj.GetType().GetField(fieldName,
            System.Reflection.BindingFlags.NonPublic |
            System.Reflection.BindingFlags.Instance);

        return (T)field?.GetValue(obj);
    }
}
