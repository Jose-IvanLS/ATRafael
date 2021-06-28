using System;
using ATRafael;
using System.Collections.Generic;



namespace ClassLibrary1 {
    public class Negocio {

        private PersistenciaAmigo persistenciaAmigo = new PersistenciaAmigo();

        /*public void SalvarAmigo(string nome, string sobrenome, DateTime aniversario) {
            Amigo amigo = new Amigo(nome, sobrenome, aniversario);
            persistenciaAmigo.Create(amigo);
        }*/
        public void SalvarAmigo() {
            Console.WriteLine("Digite o nome");
            string nome = Console.ReadLine();
            Console.WriteLine("Digite o sobrenome");
            string sobrenome = Console.ReadLine();
            Console.WriteLine("Digite a data de aniversário(dd/mm/aaaa)");
            DateTime aniversario = Convert.ToDateTime(Console.ReadLine());
            Amigo amigo = new Amigo(nome, sobrenome, aniversario);
            persistenciaAmigo.Create(amigo);
        }

        public void ListarAmigos() {
            var amigos = persistenciaAmigo.GetAll();
            foreach(Amigo amigo in amigos) {
                Console.WriteLine($"ID: {amigo.Id}\nNome: {amigo.Nome}\nSobrenome: {amigo.Sobrenome}\nAniversário: {amigo.Aniversario.ToString("d")}");
                CalculaAniversario(amigo.Aniversario);
            }
        }

        public void EditarAmigo(int id) {
            Amigo amigo = new Amigo();
            Console.WriteLine("Digite o novo nome:");
            amigo.Nome = Console.ReadLine();
            Console.WriteLine("Digite o novo sobrenome:");
            amigo.Sobrenome = Console.ReadLine();
            Console.WriteLine("Digite a nova data:");
            amigo.Aniversario = Convert.ToDateTime(Console.ReadLine());
            persistenciaAmigo.Update(amigo, id);
        }

        public void ApagarAmigo(int id) {
            persistenciaAmigo.Delete(id);
        }

        private void CalculaAniversario(DateTime data) {
            DateTime hoje = DateTime.Today;
            if(data.Day <= hoje.Day && data.Month <= hoje.Month) {
                if(data.DayOfYear >= hoje.DayOfYear) {
                    Console.WriteLine($"Faltam {data.DayOfYear + (data.DayOfYear - hoje.DayOfYear)} dias para o aniversário.\n");
                }
                else {
                    Console.WriteLine($"Faltam {hoje.DayOfYear + (hoje.DayOfYear - data.DayOfYear)} dias para o aniversário.\n");
                }
            }
            if(data.Day > hoje.Day || data.Month > hoje.Month) {
                Console.WriteLine("Faltam " + ((data.DayOfYear - hoje.DayOfYear))+ " dias para o aniversário.\n");
            }
        }
    }
}
