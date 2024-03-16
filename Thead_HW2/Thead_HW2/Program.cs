
using Thead_HW2;

List <Client> clients = new List <Client> ();
var barbershop = new Barbershop (); 

for (var i= 0; i < 10; i++)
{
    clients.Add(new Client(barbershop));
}

Thread.Sleep(5000);

for (var i = 0; i < 10; i++)
{
    clients.Add(new Client(barbershop));
}