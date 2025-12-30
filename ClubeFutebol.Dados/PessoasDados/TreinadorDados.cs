/*
*	<copyright file="TreinadorDados.cs"
*		Copyright (c) 2025 All Rights Reserved
*	</copyright>
* 	<author>a31508goncalobraga</author>
*	<description></description>
**/

using ClubeFutebol.BOO.Pessoas;
using ClubeFutebol.Dados.Interfaces;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


namespace ClubeFutebol.Dados.Pessoas
{
    public class TreinadorDados : InterfaceTreinadorDados
    {
        #region Atributos

        private readonly List<Treinador> treinadores;

        #endregion
        #region Construtor

        public TreinadorDados()
        {
            treinadores = new List<Treinador>();
        }


        #endregion

        // Criação do Treinador 
        public Treinador CriarTreinador(
            short anosExperiencia,
            string tatica,
            string nome,
            byte idade,
            string nacionalidade,
            string genero,
            int numeroSocio,
            int contacto)
        {
            Treinador t = new Treinador(
                anosExperiencia,
                tatica,
                nome,
                idade,
                nacionalidade,
                genero,
                numeroSocio,
                contacto
            );

            treinadores.Add(t);
            return t;
        }


        // Atualização de dados básicos
        public bool AtualizarTreinador(
            Treinador treinador,
            short anosExperiencia,
            string tatica)
        {
            treinador.AnosExperiencia = anosExperiencia;
            treinador.Tatica = tatica;
            return true;
        }
        public Treinador ProcurarTreinadorPorNumeroSocio(int numeroSocio)
        {
            foreach (Treinador t in treinadores)
            {
                if (t.NumeroSocio == numeroSocio)
                    return t;
            }
            return null;
        }

        public IReadOnlyList<Treinador> ListarTreinadores()
        {
            return treinadores.AsReadOnly();
        }

        public bool GuardarTreinadores(string ficheiro)
        {
            try
            {
                using (FileStream fs = new FileStream(ficheiro, FileMode.Create))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(fs, treinadores);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool LerTreinadores(string ficheiro)
        {
            if (!File.Exists(ficheiro))
                return false;

            try
            {
                using (FileStream fs = new FileStream(ficheiro, FileMode.Open))
                {
                    BinaryFormatter bf = new BinaryFormatter();

                    treinadores.Clear();
                    treinadores.AddRange((List<Treinador>)bf.Deserialize(fs));
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}