using ApiPosiciones.Controllers;
using System;
using Xunit;

namespace XUnitPosiciones
{
    public class TestPosicionesController
    {
        [Fact]
        public void Get_PalabraNoExiste_RetornaVacio()
        {
            var controller = new PosicionController();
            var resp = controller.Get("PRUEBA");
            Assert.True(RetornoVacio(resp));
        }

        private bool RetornoVacio(int[,] resp)
        {
            foreach (var elemento in resp)
            {
                if (elemento != 0)
                {
                    return false;
                }
            }
            return true;
        }

        private bool NoRetornoVacio(int[,] resp)
        {
            foreach (var elemento in resp)
            {
                if (elemento != 0)
                {
                    return true;
                }
            }
            return false;
        }

        [Fact]
        public void Get_BusquedadAutomatica_RetornaValores()
        {
            var controller = new PosicionController();
            var resp = controller.Get();
            var resp2 = controller.Get("JAVA");
            Assert.Equal(resp, resp2);
        }

        [Fact]
        public void Get_BusquedadIzquierda_EncuentraPalabra()
        {
            var controller = new PosicionController();
            var resp = controller.Get("OAYO");
            Assert.True(NoRetornoVacio(resp));
        }

        [Fact]
        public void Get_BusquedadDerecha_EncuentraPalabra()
        {
            var controller = new PosicionController();
            var resp = controller.Get("TELEFE");
            Assert.True(NoRetornoVacio(resp));
        }

        [Fact]
        public void Get_BusquedadAbajo_EncuentraPalabra()
        {
            var controller = new PosicionController();
            var resp = controller.Get("VIACOM");
            Assert.True(NoRetornoVacio(resp));
        }

        [Fact]
        public void Get_BusquedadArriba_EncuentraPalabra()
        {
            var controller = new PosicionController();
            var resp = controller.Get("RSRH");
            Assert.True(NoRetornoVacio(resp));
        }

        [Fact]
        public void Get_BusquedadArribaDerecha_EncuentraPalabra()
        {
            var controller = new PosicionController();
            var resp = controller.Get("YORC");
            Assert.True(NoRetornoVacio(resp));
        }

        [Fact]
        public void Get_BusquedadArribaIzquierda_EncuentraPalabra()
        {
            var controller = new PosicionController();
            var resp = controller.Get("YAQ");
            Assert.True(NoRetornoVacio(resp));
        }

        [Fact]
        public void Get_BusquedadAbajoDerecha_EncuentraPalabra()
        {
            var controller = new PosicionController();
            var resp = controller.Get("VORT");
            Assert.True(NoRetornoVacio(resp));
        }

        [Fact]
        public void Get_BusquedadAbajo_NoEncuentraPalabra()
        {
            var controller = new PosicionController();
            var resp = controller.Get("COSA");
            Assert.True(RetornoVacio(resp));
        }

        [Fact]
        public void Get_BusquedadAbajoIzquierda_NoEncuentraPalabra()
        {
            var controller = new PosicionController();
            var resp = controller.Get("JAVAS");
            Assert.True(RetornoVacio(resp));
        }

        [Fact]
        public void Get_BusquedadAbajoDerecha_NoEncuentraPalabra()
        {
            var controller = new PosicionController();
            var resp = controller.Get("SOCA");
            Assert.True(RetornoVacio(resp));
        }

        [Fact]
        public void Get_BusquedadArribaDerecha_NoEncuentraPalabra()
        {
            var controller = new PosicionController();
            var resp = controller.Get("AVAS");
            Assert.True(RetornoVacio(resp));
        }

        [Fact]
        public void Get_BusquedadAbajoPuntas_EncuentraPalabra()
        {
            var controller = new PosicionController();
            var resp = controller.Get("TAUF");
            Assert.True(NoRetornoVacio(resp));
        }
    }
}
