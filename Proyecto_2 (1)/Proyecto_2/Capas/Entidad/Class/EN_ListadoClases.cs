using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Proyecto_2.Capas.Entidad.Class
{
   
        [Serializable]
        [DataContract]
        public class EN_ListadoClases
        {
            string _classId;
            string _schoolId;
            string _classname;
            string _descripcion;

            public EN_ListadoClases(string SchoolId, string ClassName, string Descripcion, string classId)
            {
                
                _schoolId = SchoolId;
                _classname = ClassName;
                _descripcion = Descripcion;
                _classId = classId;

        }

            public EN_ListadoClases(IDataReader reader)
            {
                /*LOS ANARANJOS SON EL NOMBRE EXACTO DE LA COLUMNA DE LA BD*/
                
                _schoolId = reader["SchoolId"].ToString();
                _classname = reader["ClassName"].ToString(); //NOMBRES EXACTOS DE LA BD se llama CLASSNAME NO SCHOOLNAME
                _descripcion = reader["Description"].ToString();
                _classId = reader["ClassId"].ToString();

        }

            [DataMember]
           
            public string SchoolId
            {
                get { return _schoolId; }
                set { _schoolId = value; }
            }

            [DataMember]
            public string ClassName
            {
                get { return _classname; }
                set { _classname = value; }
            }

            [DataMember]
            public string Descripcion
            {
                get { return _descripcion; }
                set { _descripcion = value; }
            }

            [DataMember]
            public string ClassId
            {
                get { return _classId; }
                set { _classId = value; }
            }
    }
    
}