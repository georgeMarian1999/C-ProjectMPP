using System;
using Problem11.Repositories;
using Problem11.Model;
using System.Collections.Generic;

namespace Problem11
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            AngajatRepository angajat = new AngajatRepository();
            Console.WriteLine(angajat.findOne(1).User);
            CursaRepository cursa = new CursaRepository();
            Console.WriteLine(cursa.findOne(1).Capacitate);
            EchipaRepository echipaRepository = new EchipaRepository();
            Console.WriteLine(echipaRepository.findOne(1).Nume);
            ParticipantRepository participant = new ParticipantRepository();
            Console.WriteLine(participant.findOne(1).Nume);

            Cursa C = new Cursa(100,900);
            cursa.save(C);
            Console.WriteLine(cursa.findOne(100).Capacitate);

            Echipa E = new Echipa(200, "test");
            echipaRepository.save(E);
            Console.WriteLine(echipaRepository.findOne(200).Nume);

            Participant P = new Participant(600, "test1", 200);
            participant.save(P);
            Console.WriteLine(participant.findOne(600).Nume);

            cursa.delete(100);
            echipaRepository.delete(200);
            participant.delete(600);

            int maxim = participant.FindMaxId();
            Console.WriteLine(maxim);

            Console.WriteLine(cursa.findIdByCapacitate(500));

            List<DTOBJCursa> list = cursa.GroupByCapacitate();

            foreach (DTOBJCursa test in list)
            {
                Console.Write(test.Capacitate);
                Console.Write(" ");
                Console.WriteLine(test.NrInscrisi);
            }
            Console.WriteLine(angajat.LocalLogin("mgar1992", "12234"));
            Console.WriteLine(angajat.LocalLogin("mgar1992", "1234"));
            Console.WriteLine(echipaRepository.FindIdByName("BMW"));


            List<DTOBJPart> list2 = echipaRepository.cautare("Suzuki");
            foreach(DTOBJPart test2 in list2)
            {
                Console.Write(test2.Nume);
                Console.Write(" ");
                Console.WriteLine(test2.Capacitate);
            }






        }
    }
}
