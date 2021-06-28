using System;
using System.Collections.Generic;
using System.Text;
using ATRafael;


namespace ClassLibrary1 {
    public interface IPersistenciaAmigo {
        public void Create(Amigo amigo);
        public void Update(Amigo amigo, int id);
        public void Delete(int id);
        public List<Amigo> GetAll();
    }
}
