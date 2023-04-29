using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Proyecto_2.Capas.Entidad.Teacher_Course
{
    [Serializable]
    [DataContract]
    public class EN_ListadoCurso_Profesores
    {
      
            string _teacherId;
            string _courseId;

            public EN_ListadoCurso_Profesores(string TeacherId, string CourseId)
            {

                _teacherId = TeacherId;
                _courseId = CourseId;

            }

            public EN_ListadoCurso_Profesores(IDataReader reader)
            {
                /*LOS ANARANJOS SON EL NOMBRE EXACTO DE LA COLUMNA DE LA BD*/
                _teacherId = reader["TeacherId"].ToString();
                _courseId = reader["CourseId"].ToString();
            }

            [DataMember]

            public string TeacherId
            {
                get { return _teacherId; }
                set { _teacherId = value; }
            }

            [DataMember]
            public string CourseId
            {
                get { return _courseId; }
                set { _courseId = value; }
            }
        }
}