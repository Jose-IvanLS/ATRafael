using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1 {
    public class Tela {

        public Tela() {
            int a = MenuInicial();
            while(a != 5) {
                GerenciadorEscolha(a);
                a = MenuInicial();
            }
            Console.WriteLine("PROGRAMA ENCERRADO.");
        }

        private int MenuInicial() {
            Console.WriteLine("||============= Gerenciamento de aniversários de Amigos =============||");
            Console.WriteLine("1 - Cadastrar\n2 - Listar\n3 - Editar\n4 - Excluir\n5 - Sair");
            int escolha = Convert.ToInt32(Console.ReadLine());
            return escolha;
        }
        private void GerenciadorEscolha(int n) {
            Negocio negocio = new Negocio();
            int id = 0;
            switch(n) {
                case 1:
                    //Salvando pessoas
                    negocio.SalvarAmigo();
                    Console.WriteLine("AMIGO CADASTRADO COM SUCESSO!\n");
                    break;
                case 2:
                    //Lista de pessoas
                    Console.WriteLine("\nAmigos cadastrados até o momento:");
                    negocio.ListarAmigos();
                    break;
                case 3:
                    //Edição de pessoa
                    negocio.ListarAmigos();
                    Console.WriteLine("Selecione pelo ID uma das pessoas acima para editar:\n");
                    id = Convert.ToInt32(Console.ReadLine());
                    negocio.EditarAmigo(id);
                    Console.WriteLine("AMIGO EDITADO COM SUCESSO!\n");
                    break;
                case 4:
                    //Método de exclusão de pessoa
                    negocio.ListarAmigos();
                    Console.WriteLine("Digite to ID de um dos amigos acima para excluir");
                    id = Convert.ToInt32(Console.ReadLine());
                    negocio.ApagarAmigo(id);
                    Console.WriteLine("AMIGO EXCLUIDO COM SUCESSO!\n");
                    break;
            }
        }
    }
}
