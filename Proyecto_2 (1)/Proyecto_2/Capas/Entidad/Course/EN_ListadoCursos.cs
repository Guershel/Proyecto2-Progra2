using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Proyecto_2.Capas.Entidad.Course
{
    
        [Serializable]
        [DataContract]
        public class EN_ListadoCursos
        {
            string _courseId;
            string _schoolId;
            string _courseName;
            string _descripcion;

            public EN_ListadoCursos(string courseId, string CourseName, string SchoolId,  string Descripcion)
            {
                _courseId = courseId;
                _courseName = CourseName;
                 _schoolId = SchoolId;
                _descripcion = Descripcion;


            }

            public EN_ListadoCursos(IDataReader reader)
            {
            /*LOS ANARANJOS SON EL NOMBRE EXACTO DE LA COLUMNA DE LA BD*/
            
                _courseId = reader["CourseId"].ToString();
                _courseName = reader["CourseName"].ToString();
                _schoolId = reader["SchoolId"].ToString();              
                _descripcion = reader["Description"].ToString();

            }

            [DataMember]

            public string CourseId
        {
                get { return _courseId; }
                set { _courseId = value; }
            }

            [DataMember]

            public string SchoolId
            {
                get { return _schoolId; }
                set { _schoolId = value; }
            }

            [DataMember]
            public string CourseName
            {
                get { return _courseName; }
                set { _courseName = value; }
            }

            [DataMember]
            public string Descripcion
            {
                get { return _descripcion; }
                set { _descripcion = value; }
            }
        }  
}