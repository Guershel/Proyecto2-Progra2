using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Proyecto_2.Capas.Entidad.Student_Course
{
    [Serializable]
    [DataContract]
    public class EN_ListadoCurso_Estudiantes
    {

        string _studentId;
        string _courseId;

        public EN_ListadoCurso_Estudiantes(string StudentId, string CourseId)
        {

            _studentId = StudentId;
            _courseId = CourseId;

        }

        public EN_ListadoCurso_Estudiantes(IDataReader reader)
        {
            /*LOS ANARANJOS SON EL NOMBRE EXACTO DE LA COLUMNA DE LA BD*/
            _studentId = reader["StudentId"].ToString();
            _courseId = reader["CourseId"].ToString();
        }

        [DataMember]

        public string StudentId
        {
            get { return _studentId; }
            set { _studentId = value; }
        }

        [DataMember]
        public string CourseId
        {
            get { return _courseId; }
            set { _courseId = value; }
        }
    }
}