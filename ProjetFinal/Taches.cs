using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFinal
{
    public class Taches
    {
        private int _id;
        private int _numprojet;
        private int _numemp;
        private int _semaine;
        private int _nbheures;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public int NumProjet
        {
            get { return _numprojet; }
            set { _numprojet = value; }
        }

        public int NumEmp
        {
            get { return _numemp; }
            set { _numemp = value; }
        }

        public int Semaine
        {
            get { return _semaine; }
            set
            {
                if (value >= 1 && value <= 52)
                {
                    _semaine = value;
                }
                else
                {
                    throw new ArgumentException("La semaine doit être comprise entre 1 et 52.");
                }
            }
        }

        public int NbHeures
        {
            get { return _nbheures; }
            set
            {
                if (value >= 0)
                {
                    _nbheures = value;
                }
                else
                {
                    throw new ArgumentException("Le nombre d'heures doit être positif.");
                }
            }
        }
        
    }
}
