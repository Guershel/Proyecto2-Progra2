using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Proyecto_2.Capas.Entidad.Grade
{
    [Serializable]
    [DataContract]
    public class EN_ListadoGrade
    {
            string _gradeId;
            string _studentId;
            string _courseId;
            string _grade;
            string _comment;

        public EN_ListadoGrade(string gradeId, string StudentId, string CourseId, string grade, string comment)
            {
            _gradeId = gradeId;
            _studentId = StudentId;
            _courseId = CourseId;
            _grade = grade;
            _comment = comment;


        }

            public EN_ListadoGrade(IDataReader reader)
            {
            /*LOS ANARANJOS SON EL NOMBRE EXACTO DE LA COLUMNA DE LA BD*/
            _gradeId = reader["GradeId"].ToString();
            _studentId = reader["StudentId"].ToString();
            _courseId = reader["CourseId"].ToString();
            _grade = reader["Grade"].ToString();
            _comment = reader["Comment"].ToString();
    
        }
                [DataMember]

                public string GradeId
                {
                    get { return _gradeId; }
                    set { _gradeId = value; }
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

            [DataMember]
            public string Grade
            {
                get { return _grade; }
                set { _grade = value; }
            }

            [DataMember]
            public string Comment
            {
                get { return _comment; }
                set { _comment = value; }
            }
    }
}