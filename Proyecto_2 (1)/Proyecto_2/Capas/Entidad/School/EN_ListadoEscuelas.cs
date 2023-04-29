    using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Proyecto_2.Capas.Entidad.School
{
    [Serializable]
    [DataContract]
    public class EN_ListadoEscuelas
    {
        string _id;
        string _nombre;
        string _descripcion;
        string _direccion;
        string _telefono;
        string _codigoPostal;
        string _direccionPostal;

        public EN_ListadoEscuelas(string id, string nombre, string descripcion, string direccion, string telefono, 
            string codigoP, string direccioP)
        {
            _id = id;
            _nombre = nombre;
            _descripcion = descripcion;
            _direccion = direccion;
            _telefono = telefono;
            _codigoPostal = codigoP;
            _direccionPostal = direccioP;

        }

        public EN_ListadoEscuelas(IDataReader reader)
        {
            /*LOS ANARANJOS SON EL NOMBRE EXACTO DE LA COLUMNA DE LA BD*/
            _id = reader["SchoolId"].ToString();
            _nombre = reader["SchoolName"].ToString();
            _descripcion = reader["Description"].ToString();
            _direccion = reader["Address"].ToString();
            _telefono = reader["Phone"].ToString();
            _codigoPostal = reader["PostCode"].ToString();
            _direccionPostal = reader["PostAddress"].ToString();
        }

        [DataMember]
        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }

        [DataMember]
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        [DataMember]
        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }


        [DataMember]
        public string Direccion
        {
            get { return _direccion; }
            set { _direccion = value; }
        }


        [DataMember]
        public string Telefono
        {
            get { return _telefono; }
            set { _telefono = value; }
        }


        [DataMember]
        public string CodigoPostal
        {
            get { return _codigoPostal; }
            set { _codigoPostal = value; }
        }


        [DataMember]
        public string DIreccionPostal
        {
            get { return _direccionPostal; }
            set { _direccionPostal = value; }
        }

    }
}