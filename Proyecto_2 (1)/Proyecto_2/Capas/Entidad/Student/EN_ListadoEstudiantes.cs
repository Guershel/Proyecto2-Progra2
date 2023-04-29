using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Proyecto_2.Capas.Entidad.Student
{
        [Serializable]
        [DataContract]
    public class EN_ListadoEstudiantes
    {

            string _studentId;
            string _classId;
            string _StudentName;
            string _StudentNumber;
            string _TotalGrade;
            string _Address;
            string _Phone; 
            string _Email;

        public EN_ListadoEstudiantes(string studentId, string classId, string studentName, string studentNumber, string totalGrade, 
            string address, string phone, string email)

            {
            _studentId = studentId;
            _classId = classId;
            _StudentName = studentName;
            _StudentNumber = studentNumber;
            _TotalGrade = totalGrade;
            _Address = address;
            _Phone = phone;
            _Email = email;


        }

            public EN_ListadoEstudiantes(IDataReader reader)
            {
            /*LOS ANARANJOS SON EL NOMBRE EXACTO DE LA COLUMNA DE LA BD*/
            
            _studentId = reader["StudentId"].ToString();
            _classId = reader["ClassId"].ToString();
            _StudentName = reader["StudentName"].ToString();
            _StudentNumber = reader["StudentNumber"].ToString();
            _TotalGrade = reader["TotalGrade"].ToString();
            _Address = reader["Address"].ToString();
            _Phone = reader["Phone"].ToString();
            _Email = reader["Email"].ToString();


        }

             [DataMember]

        public string StudentId
        {
            get { return _studentId; }
            set { _studentId = value; }
        }
            [DataMember]
        public string ClassId
            {
                get { return _classId; }
                set { _classId = value; }
            }

            [DataMember]
            public string StudentName
            {
                get { return _StudentName; }
                set { _StudentName = value; }
            }

            [DataMember]
            public string StudentNumber
            {
                get { return _StudentNumber; }
                set { _StudentNumber = value; }
            }
           
            [DataMember]
            public string TotalGrade
            {
                get { return _TotalGrade; }
                set { _TotalGrade = value; }
            }

            [DataMember]
            public string Address
            {
                get { return _Address; }
                set { _Address = value; }
            }

            [DataMember]
            public string Phone
            {
                get { return _Phone; }
                set { _Phone = value; }
            }

            [DataMember]
            public string Email
            {
                get { return _Email; }
                set { _Email = value; }
            }

    }
}