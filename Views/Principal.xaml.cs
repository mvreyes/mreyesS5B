using mreyesS5B.Models;

namespace mreyesS5B.Views;

public partial class Principal : ContentPage
{
	public Principal()
	{
		InitializeComponent();
	}

    private void btnAdd_Clicked(object sender, EventArgs e)
    {
        App.personRepo.AddNewPerson(txtName.Text);
        lblStatus.Text = App.personRepo.status;
    }

    private void btnMostrar_Clicked(object sender, EventArgs e)
    {
        List<Persona> people = App.personRepo.GetAllPeople();
        listaPersona.ItemsSource = people;
    }
}