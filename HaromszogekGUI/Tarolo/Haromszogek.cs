using HaromszogekSzoftverfejleszto.Modell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Diagnostics;

namespace HaromszogekSzoftverfejleszto.Tarolo
{
    class Haromszogek
    {
        List<Haromszog> haromszogek;

        public Haromszogek()
        {
            haromszogek = new List<Haromszog>();
        }

        public List<Haromszog> getHaromszogek()
        {
            return haromszogek;
        }

        public int getNextId()
        {
            int max = -1;
            foreach(Haromszog h in haromszogek)
            {
                if (h.getId() > max)
                    max = h.getId();
            }
            return max + 1;
        }

        public void beolvas()
        {
            try
            {
                StreamReader sr = new StreamReader("01haromszogek.txt");
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    try
                    {
                        Haromszog h = new Haromszog(line);
                        h.setID(getNextId());
                        haromszogek.Add(h);
                    }
                    catch (Exception e)
                    {
                        Debug.WriteLine(e.Message);
                    }
                }
            } catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }

        public int getHaromszogekSzama()
        {
            return haromszogek.Count;
        }

        public bool szerkeszthetoE(int n)
        {
            try
            {
                if (haromszogek.ElementAt(n).szerkeszthetoE())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                throw new TaroloException(n + ". háromszög nem létezik!");
            }
        }

        public double getSzerkeszthetoHaromszogekOsszterulete()
        {
            double terulet = 0;
            foreach(Haromszog h in haromszogek)
            {
                if (h.szerkeszthetoE())
                    terulet = terulet + h.getTerulet();
            }
            return terulet;
        }

        public Haromszog getAdottElem(int index)
        {
            try
            {
                return haromszogek.ElementAt(index);
            }
            catch (RepositoryException re)
            {
                Debug.WriteLine(index + ". elem nem létezik.");
            }
            return null;
        }

        public void torolIdAlapjan(int id)
        {
            /*  int index = 0;
              foreach(Haromszog h in haromszogek)
              {
                  if (h.getId()==id)
                  {
                      haromszogek.RemoveAt(index);
                      return;
                  }
                  index = index + 1;
              }
              return;*/

            haromszogek.RemoveAt(haromszogek.FindIndex(h => h.getId() == id));
        }

        public void hozzaadHaromszoget(Haromszog h)
        {
            int id = getNextId();
            h.setID(id);
            haromszogek.Add(h);
        }

        public void modositHaromszoget(int id, Haromszog ujHaromszogAdatai)
        {
            try
            {
                Haromszog modositandoHaromszog =
                    haromszogek.Find(h => h.getId() == id);
                modositandoHaromszog.set(ujHaromszogAdatai);
            }
            catch (Exception e)
            {
                throw new TaroloException(id + ". háromszög nem létezik!");
            }
        }
    }
}
