using System;
using System.Collections.Generic;
using System.Text;

namespace ATRafael {
    public class Amigo {
        public int Id { get; set;}
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime Aniversario { get; set; }

        public Amigo() {
        
        }

        public Amigo(string nome, string sobrenome, DateTime aniversario) {
            this.Nome = nome;
            this.Sobrenome = sobrenome;
            this.Aniversario = aniversario;
        }
    }
}
