using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teretana_Radnik.MVVM.Models
{
    public class Uplata
    {
		private DateTime datumUplate;
		private NacinUplate nacinUplate;

		public NacinUplate NacinUplate
		{
			get { return nacinUplate; }
			set { nacinUplate = value; }
		}


		public DateTime DatumUplate
		{
			get { return datumUplate; }
			set { datumUplate = value; }
		}

        public Uplata(DateTime datumUplate, NacinUplate nacinUplate)
        {
            this.datumUplate = datumUplate;
            this.nacinUplate = nacinUplate;
        }
    }
}
