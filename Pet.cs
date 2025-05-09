using System;
using System.Collections.Generic;

namespace PetVirtual.Models
{
    public enum EstadoDeSaude { Saudavel, Doente }

    public class Pet
    {
        public string Nome { get; private set; }
        public int Energia { get; private set; }
        public int Fome { get; private set; }
        public int Felicidade { get; private set; }
        public int Idade { get; private set; }
        public bool Vivo { get; private set; }
        public int Nivel { get; private set; }
        public int Experiencia { get; private set; }
        public EstadoDeSaude EstadoSaude { get; private set; }
        public List<string> Conquistas { get; private set; }

        public Pet(string nome)
        {
            Nome = nome;
            Energia = 100;
            Fome = 0;
            Felicidade = 100;
            Idade = 0;
            Vivo = true;
            Nivel = 1;
            Experiencia = 0;
            EstadoSaude = EstadoDeSaude.Saudavel;
            Conquistas = new List<string>();
        }

        public void Envelhecer()
        {
            Idade++;
            if (Idade > 30)
                Morrer("seu pet ficou muito velho...");
        }

        public void AlterarEnergia(int valor)
        {
            Energia += valor;
            if (Energia > 100) Energia = 100;
            if (Energia <= 0)
                Morrer("ficou sem energia...");
        }

        public void AlterarFome(int valor)
        {
            Fome += valor;
            if (Fome < 0) Fome = 0;
            if (Fome >= 100)
                Morrer("morreu de fome...");
        }

        public void AlterarFelicidade(int valor)
        {
            Felicidade += valor;
            if (Felicidade > 100) Felicidade = 100;
            if (Felicidade < 0)
                Felicidade = 0;

            VerificarNivel();
        }

        public void Morrer(string causa)
        {
            Vivo = false;
            Console.WriteLine($"⚠️ O pet {Nome} morreu porque {causa}");
        }

        public void VerificarNivel()
        {
            // Verifica se o pet subiu de nível
            if (Felicidade >= 5)
            {
                Experiencia++;
                Felicidade = 0;  // Reseta a felicidade
            }

            if (Experiencia >= 10)
            {
                Nivel++;
                Experiencia = 0; // Reseta a experiência
                Conquistas.Add($"Alcançou o nível {Nivel}");
                Energia += 5; // Ganha +5 de energia
                Felicidade += 5; // Ganha +5 de felicidade
                Console.WriteLine($"🎉 {Nome} subiu para o nível {Nivel}!");
            }
        }

        public void LevarAoVeterinario()
        {
            if (EstadoSaude == EstadoDeSaude.Doente)
            {
                if (Energia >= 10)
                {
                    Energia -= 10; // Gasta energia para curar
                    EstadoSaude = EstadoDeSaude.Saudavel;
                    Console.WriteLine($"{Nome} foi curado! Agora está saudável.");
                }
                else
                {
                    Console.WriteLine($"{Nome} não tem energia suficiente para ir ao veterinário.");
                }
            }
            else
            {
                Console.WriteLine($"{Nome} está saudável! Não precisa de tratamento.");
            }
        }

        public void MostrarStatus()
        {
            Console.WriteLine($"\n📊 Status de {Nome}");
            Console.WriteLine($"Idade: {Idade}");
            Console.WriteLine($"Energia: {Energia}");
            Console.WriteLine($"Fome: {Fome}");
            Console.WriteLine($"Felicidade: {Felicidade}");
            Console.WriteLine($"Vivo? {(Vivo ? "Sim" : "Não")}");
            Console.WriteLine($"Nível: {Nivel}");
            Console.WriteLine($"Experiência: {Experiencia}");
            Console.WriteLine($"Estado de Saúde: {EstadoSaude}");
            Console.WriteLine($"Conquistas: {string.Join(", ", Conquistas)}");
        }
    }
}
