using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dominio;

namespace Negocio
{
    public class NegocioArticulo
    {
        //ATRIBUTOS:
        private Articulo _articulo;
        private AccesoDatos _accesoDatos;
        private List<Articulo> _listaArticulos;
        public int CantArt { get; set; }

        //METODOS:
        // Listar Articulos:
        public List<Articulo> listarArticulos(int param, string id = null)
        {
            string query = (param == 0) ?
                "SELECT a.Id, a.Codigo, a.IdCategoria, a.Activo, c.Descripcion as Categoria, a.IdMarca, m.Descripcion as Marca, a.Descripcion, a.Nombre, a.Precio, a.ImagenUrl FROM ARTICULOS a LEFT JOIN MARCAS m ON a.IdMarca = m.Id LEFT JOIN CATEGORIAS c ON a.IdCategoria = c.Id" :
                "SP_Listar";
            if (id != null && param == 0)
                query = "SELECT a.Id, a.Codigo, a.IdCategoria, a.Activo, c.Descripcion as Categoria, a.IdMarca, m.Descripcion as Marca, a.Descripcion, a.Nombre, a.Precio, a.ImagenUrl FROM ARTICULOS a LEFT JOIN MARCAS m ON a.IdMarca = m.Id LEFT JOIN CATEGORIAS c ON a.IdCategoria = c.Id WHERE a.Id = " + id;

            _listaArticulos = new List<Articulo>();
            _accesoDatos = new AccesoDatos();
            try
            {
                _accesoDatos.setearQuery(query);
                _accesoDatos.ejecutarLectura();
                while (_accesoDatos._lector.Read())
                {
                    _articulo = new Articulo();

                    //Asignamos valores al obj Articulo:
                    _articulo._Id = (int)_accesoDatos._lector["Id"];
                    if (!(_accesoDatos._lector["Codigo"] is DBNull))
                        _articulo._codArticulo = (string)_accesoDatos._lector["Codigo"];


                    _articulo._categoria._Id = (int)_accesoDatos._lector["IdCategoria"];
                    if (!(_accesoDatos._lector["Categoria"] is DBNull))
                        _articulo._categoria._Descripcion = (string)_accesoDatos._lector["Categoria"];
                    else
                        _articulo._categoria._Descripcion = "";
                    _articulo._marca._Id = (int)_accesoDatos._lector["IdMarca"];
                    if (!(_accesoDatos._lector["Marca"] is DBNull))
                        _articulo._marca._Descripcion = (string)_accesoDatos._lector["Marca"];


                    if (!(_accesoDatos._lector["Nombre"] is DBNull))
                        _articulo._nombre = (string)_accesoDatos._lector["Nombre"];
                    if (!(_accesoDatos._lector["Descripcion"] is DBNull))
                        _articulo._descripcion = (string)_accesoDatos._lector["Descripcion"];
                    if (!(_accesoDatos._lector["Precio"] is DBNull))
                        _articulo._precio = (decimal)_accesoDatos._lector["Precio"];
                    if (!(_accesoDatos._lector["ImagenUrl"] is DBNull))
                        _articulo._urlImagen = (string)_accesoDatos._lector["ImagenUrl"];
                    else
                        _articulo._urlImagen = "image-mising.png";
                    if (!(_accesoDatos._lector["Activo"] is DBNull))
                        _articulo._activo = (bool)(_accesoDatos._lector["Activo"]);
                    //_articulo._activo = Convert.ToBoolean( _accesoDatos._lector["Activo"]);

                    _articulo.redondear(2);
                    _listaArticulos.Add(_articulo);
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _accesoDatos.cerrarConexion();
            }
            CantArt = _listaArticulos.Count;
            return _listaArticulos;
        }

        // Agregar Articulo:
        public void agregarArticulo(Articulo art)
        {
            _accesoDatos = new AccesoDatos();
            try
            {
                art.redondear(2);
                _accesoDatos.setearQuery($"INSERT INTO ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, ImagenUrl, Precio) VALUES ('{art._codArticulo}','{art._nombre}', '{art._descripcion}', @idMarca, @idCategoria, '{art._urlImagen}', @precio)");
                //_accesoDatos.setearQuery($"INSERT INTO ARTICULOS VALUES (@codart, @nombre, @descripcion, @idMarca, @idCategoria, @urlImg, @precio)");
                //_accesoDatos.setearParametro("@codart", art._codArticulo);
                //_accesoDatos.setearParametro("@nombre", art._nombre);
                //_accesoDatos.setearParametro("@descripcion", art._descripcion);
                //_accesoDatos.setearParametro("@urlImg", art._urlImagen);
                _accesoDatos.setearParametro("@idMarca", art._marca._Id);
                _accesoDatos.setearParametro("@idCategoria", art._categoria._Id);
                _accesoDatos.setearParametro("@precio", art._precio);
                _accesoDatos.ejecutarQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _accesoDatos.cerrarConexion();
            }
        }
        // Agregar Articulo con SP
        public void agregarArticuloSP(Articulo art)
        {
            _accesoDatos = new AccesoDatos();
            try
            {
                art.redondear(2);
                _accesoDatos.setSP("SP_Agregar");
                _accesoDatos.setearParametro("@Codigo", art._codArticulo);
                _accesoDatos.setearParametro("@Nombre", art._nombre);
                _accesoDatos.setearParametro("@Descripcion", art._descripcion);
                _accesoDatos.setearParametro("@IdMarca", art._marca._Id);
                _accesoDatos.setearParametro("@IdCategoria", art._categoria._Id);
                _accesoDatos.setearParametro("@ImagenUrl", art._urlImagen);
                _accesoDatos.setearParametro("@Precio", art._precio);
                _accesoDatos.ejecutarQuery();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _accesoDatos.cerrarConexion();
            }
        }

        // Modificar Articulo:
        public void modificarArticulo(Articulo art)
        {
            _accesoDatos = new AccesoDatos();
            try
            {
                art.redondear(2);
                //_accesoDatos.setearQuery($"UPDATE ARTICULOS SET Codigo = '{art._codArticulo}', Nombre = '{art._nombre}', Descripcion = '{art._descripcion}', IdMarca = {art._marca._Id}, IdCategoria = {art._categoria._Id}, ImagenUrl = '{art._urlImagen}', Precio = @precio WHERE Id = {art._Id}");
                _accesoDatos.setearQuery($"UPDATE ARTICULOS SET Codigo = @Codigo, Nombre = @Nombre, Descripcion = @Descripcion, IdMarca = @IdMarca, IdCategoria = @IdCategoria, ImagenUrl = @ImagenUrl, Precio = @precio WHERE Id = @Id");
                _accesoDatos.setearParametro("@Codigo", art._codArticulo);
                _accesoDatos.setearParametro("@Nombre", art._nombre);
                _accesoDatos.setearParametro("@Descripcion", art._descripcion);
                _accesoDatos.setearParametro("@IdMarca", art._marca._Id);
                _accesoDatos.setearParametro("@IdCategoria", art._categoria._Id);
                _accesoDatos.setearParametro("@ImagenUrl", art._urlImagen);
                _accesoDatos.setearParametro("@Precio", art._precio);
                _accesoDatos.setearParametro("@Id", art._Id);
                _accesoDatos.ejecutarQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _accesoDatos.cerrarConexion();
            }
        }
        // Modificar Articulo con SP:
        public void modificarArticuloSP(Articulo art)
        {
            _accesoDatos = new AccesoDatos();
            try
            {
                art.redondear(2);
                _accesoDatos.setSP("SP_Modificar");
                _accesoDatos.setearParametro("@Codigo", art._codArticulo);
                _accesoDatos.setearParametro("@Nombre", art._nombre);
                _accesoDatos.setearParametro("@Descripcion", art._descripcion);
                _accesoDatos.setearParametro("@IdMarca", art._marca._Id);
                _accesoDatos.setearParametro("@IdCategoria", art._categoria._Id);
                _accesoDatos.setearParametro("@ImagenUrl", art._urlImagen);
                _accesoDatos.setearParametro("@Precio", art._precio);
                _accesoDatos.setearParametro("@Id", art._Id);
                _accesoDatos.ejecutarQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _accesoDatos.cerrarConexion();
            }
        }

        // Eliminar Articulo:
        public void eliminarArticulo(int id, bool flag = false)
        {
            _accesoDatos = new AccesoDatos();
            try
            {
                if (flag)
                {
                    _accesoDatos.setSP("SP_BajaLogica");
                    _accesoDatos.setearParametro("@Id", id);
                    _accesoDatos.ejecutarQuery();
                }
                else
                {
                    //_accesoDatos.setearQuery($"DELETE FROM ARTICULOS WHERE Id = {id}");
                    _accesoDatos.setearQuery("DELETE FROM ARTICULOS WHERE Id = @Id");
                    _accesoDatos.setearParametro("@Id", id);
                    _accesoDatos.ejecutarQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _accesoDatos.cerrarConexion();
            }
        }
        // Alta Logica:
        public void altaLogica(int id)
        {
            _accesoDatos = new AccesoDatos();
            try
            {
                _accesoDatos.setSP("SP_AltaLogica");
                _accesoDatos.setearParametro("@Id", id);
                _accesoDatos.ejecutarQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _accesoDatos.cerrarConexion();
            }
        }

        // Busqueda Filtrada:
        public List<Articulo> busquedaFiltrada(Articulo art, decimal fil, string criterio)
        {
            string queryFiltrada = fitrarString(art, fil, criterio);
            _listaArticulos = new List<Articulo>();
            _accesoDatos = new AccesoDatos();
            try
            {
                _accesoDatos.setearQuery(queryFiltrada);
                _accesoDatos.ejecutarLectura();
                while (_accesoDatos._lector.Read())
                {
                    _articulo = new Articulo();
                    _articulo._Id = (int)_accesoDatos._lector["Id"];
                    if (!(_accesoDatos._lector["Codigo"] is DBNull)) _articulo._codArticulo = (string)_accesoDatos._lector["Codigo"];
                    _articulo._categoria._Id = (int)_accesoDatos._lector["IdCategoria"];
                    if (!(_accesoDatos._lector["Categoria"] is DBNull)) _articulo._categoria._Descripcion = (string)_accesoDatos._lector["Categoria"];
                    else _articulo._categoria._Descripcion = "";
                    _articulo._marca._Id = (int)_accesoDatos._lector["IdMarca"];
                    if (!(_accesoDatos._lector["Marca"] is DBNull)) _articulo._marca._Descripcion = (string)_accesoDatos._lector["Marca"];
                    if (!(_accesoDatos._lector["Nombre"] is DBNull)) _articulo._nombre = (string)_accesoDatos._lector["Nombre"];
                    if (!(_accesoDatos._lector["Descripcion"] is DBNull)) _articulo._descripcion = (string)_accesoDatos._lector["Descripcion"];
                    if (!(_accesoDatos._lector["Precio"] is DBNull)) _articulo._precio = (decimal)_accesoDatos._lector["Precio"];
                    if (!(_accesoDatos._lector["ImagenUrl"] is DBNull)) _articulo._urlImagen = (string)_accesoDatos._lector["ImagenUrl"];
                    _articulo.redondear(2);
                    _listaArticulos.Add(_articulo);
                }
                return _listaArticulos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _accesoDatos.cerrarConexion();
            }
        }

        public List<Articulo> busquedaFiltrada(string filMarca, string filTipo, decimal fil, string criterio)
        {
            string queryFiltrada = fitrarString(filMarca, filTipo, fil, criterio);
            _listaArticulos = new List<Articulo>();
            _accesoDatos = new AccesoDatos();
            try
            {
                _accesoDatos.setearQuery(queryFiltrada);
                _accesoDatos.ejecutarLectura();
                while (_accesoDatos._lector.Read())
                {
                    _articulo = new Articulo();
                    _articulo._Id = (int)_accesoDatos._lector["Id"];
                    if (!(_accesoDatos._lector["Codigo"] is DBNull)) _articulo._codArticulo = (string)_accesoDatos._lector["Codigo"];
                    _articulo._categoria._Id = (int)_accesoDatos._lector["IdCategoria"];
                    if (!(_accesoDatos._lector["Categoria"] is DBNull)) _articulo._categoria._Descripcion = (string)_accesoDatos._lector["Categoria"];
                    else _articulo._categoria._Descripcion = "";
                    _articulo._marca._Id = (int)_accesoDatos._lector["IdMarca"];
                    if (!(_accesoDatos._lector["Marca"] is DBNull)) _articulo._marca._Descripcion = (string)_accesoDatos._lector["Marca"];
                    if (!(_accesoDatos._lector["Nombre"] is DBNull)) _articulo._nombre = (string)_accesoDatos._lector["Nombre"];
                    if (!(_accesoDatos._lector["Descripcion"] is DBNull)) _articulo._descripcion = (string)_accesoDatos._lector["Descripcion"];
                    if (!(_accesoDatos._lector["Precio"] is DBNull)) _articulo._precio = (decimal)_accesoDatos._lector["Precio"];
                    if (!(_accesoDatos._lector["ImagenUrl"] is DBNull)) _articulo._urlImagen = (string)_accesoDatos._lector["ImagenUrl"];
                    if (!(_accesoDatos._lector["Activo"] is DBNull)) _articulo._activo = (bool)(_accesoDatos._lector["Activo"]);

                    _articulo.redondear(2);
                    _listaArticulos.Add(_articulo);
                }
                return _listaArticulos;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _accesoDatos.cerrarConexion();
            }
        }

        // Metodo filtro:
        private string fitrarString(Articulo art, decimal fil, string cri)
        {
            string filtroFinal;
            string filMarca = art._marca._Descripcion;
            string filCategoria = art._categoria._Descripcion;
            if (cri == "Mayor a")
            {
                filtroFinal = $"SELECT a.Id, a.Codigo, a.IdCategoria, c.Descripcion as Categoria, a.IdMarca, m.Descripcion as Marca, a.Descripcion, a.Nombre, a.Precio, a.ImagenUrl FROM ARTICULOS a LEFT JOIN MARCAS m ON a.IdMarca = m.Id LEFT JOIN CATEGORIAS c ON a.IdCategoria = c.Id WHERE c.Descripcion LIKE '{filCategoria}' AND m.Descripcion LIKE '{filMarca}' AND a.Precio > {fil}";
            }
            else if (cri == "Menor a")
            {
                filtroFinal = $"SELECT a.Id, a.Codigo, a.IdCategoria, c.Descripcion as Categoria, a.IdMarca, m.Descripcion as Marca, a.Descripcion, a.Nombre, a.Precio, a.ImagenUrl FROM ARTICULOS a LEFT JOIN MARCAS m ON a.IdMarca = m.Id LEFT JOIN CATEGORIAS c ON a.IdCategoria = c.Id WHERE c.Descripcion LIKE '{filCategoria}' AND m.Descripcion LIKE '{filMarca}' AND a.Precio < {fil}";
            }
            else
            {
                filtroFinal = $"SELECT a.Id, a.Codigo, a.IdCategoria, c.Descripcion as Categoria, a.IdMarca, m.Descripcion as Marca, a.Descripcion, a.Nombre, a.Precio, a.ImagenUrl FROM ARTICULOS a LEFT JOIN MARCAS m ON a.IdMarca = m.Id LEFT JOIN CATEGORIAS c ON a.IdCategoria = c.Id WHERE c.Descripcion LIKE '{filCategoria}' AND m.Descripcion LIKE '{filMarca}' AND a.Precio = {fil}";
            }
            return filtroFinal;
        }

        private string fitrarString(string filMarca, string filTipo, decimal fil, string cri)
        {
            string filtroFinal;
            if (string.IsNullOrEmpty(filTipo))
                filTipo = "%";
            if (string.IsNullOrEmpty(filMarca))
                filMarca = "%";
            fil = decimal.ToInt32(fil);

            if(cri == "")
            {
                filtroFinal = $"SELECT a.Id, a.Codigo, a.IdCategoria, a.Activo, c.Descripcion as Categoria, a.IdMarca, m.Descripcion as Marca, a.Descripcion, a.Nombre, a.Precio, a.ImagenUrl FROM ARTICULOS a LEFT JOIN MARCAS m ON a.IdMarca = m.Id LEFT JOIN CATEGORIAS c ON a.IdCategoria = c.Id WHERE c.Descripcion LIKE '{filTipo}' AND m.Descripcion LIKE '{filMarca}' AND a.Precio > 0";
            }
            else if (cri == "Mayor a")
            {
                filtroFinal = $"SELECT a.Id, a.Codigo, a.IdCategoria, a.Activo, c.Descripcion as Categoria, a.IdMarca, m.Descripcion as Marca, a.Descripcion, a.Nombre, a.Precio, a.ImagenUrl FROM ARTICULOS a LEFT JOIN MARCAS m ON a.IdMarca = m.Id LEFT JOIN CATEGORIAS c ON a.IdCategoria = c.Id WHERE c.Descripcion LIKE '{filTipo}' AND m.Descripcion LIKE '{filMarca}' AND a.Precio > {fil}";
            }
            else if (cri == "Menor a")
            {
                filtroFinal = $"SELECT a.Id, a.Codigo, a.IdCategoria, a.Activo, c.Descripcion as Categoria, a.IdMarca, m.Descripcion as Marca, a.Descripcion, a.Nombre, a.Precio, a.ImagenUrl FROM ARTICULOS a LEFT JOIN MARCAS m ON a.IdMarca = m.Id LEFT JOIN CATEGORIAS c ON a.IdCategoria = c.Id WHERE c.Descripcion LIKE '{filTipo}' AND m.Descripcion LIKE '{filMarca}' AND a.Precio < {fil}";
            }
            else
            {
                filtroFinal = $"SELECT a.Id, a.Codigo, a.IdCategoria, a.Activo, c.Descripcion as Categoria, a.IdMarca, m.Descripcion as Marca, a.Descripcion, a.Nombre, a.Precio, a.ImagenUrl FROM ARTICULOS a LEFT JOIN MARCAS m ON a.IdMarca = m.Id LEFT JOIN CATEGORIAS c ON a.IdCategoria = c.Id WHERE c.Descripcion LIKE '{filTipo}' AND m.Descripcion LIKE '{filMarca}' AND a.Precio = {fil}";
            }
            return filtroFinal;
        }


    }//Fin NegocioArticulo
}