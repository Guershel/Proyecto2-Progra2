using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Proyecto_2.Capas.Entidad.Teacher
{

    [Serializable]
    [DataContract]
    public class EN_ListadoProfesores
    {

        string _teacherId;
        string _schoolId;
        string _teacherName;
        string _description;


        public EN_ListadoProfesores(string teacherId, string schoolId, string teacherName, string description)

            {
            _teacherId = teacherId;
            _schoolId = schoolId;
            _teacherName = teacherName;
            _description = description;
                

            }

            public EN_ListadoProfesores(IDataReader reader)
            {
            /*LOS ANARANJOS SON EL NOMBRE EXACTO DE LA COLUMNA DE LA BD*/
            _teacherId = reader["TeacherId"].ToString();
            _schoolId = reader["SchoolId"].ToString();
            _teacherName = reader["TeacherName"].ToString();
            _description = reader["Description"].ToString();


            }


            [DataMember]

            public string TeacherId
            {
                get { return _teacherId; }
                set { _teacherId = value; }
            }
        [DataMember]

            public string SchoolId
            {
                get { return _schoolId; }
                set { _schoolId = value; }
            }

            [DataMember]
            public string TeacherName
            {
                get { return _teacherName; }
                set { _teacherName = value; }
            }

            [DataMember]
            public string Description
            {
                get { return _description; }
                set { _description = value; }
            }           

        }
    
}