/*
*	<copyright file="JogadorDados.cs"
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
    public class JogadorDados : InterfaceJogadorDados
    {
        #region Atributos

        private readonly List<Jogador> jogadores;

        #endregion
        #region Construtor

        public JogadorDados()
        {
            jogadores = new List<Jogador>();
        }


        #endregion

        public Jogador CriarJogador(

            byte numero,
            string posicao,
            string nome,
            byte idade,
            string nacionalidade,
            string genero,
            int numeroSocio,
            int contacto)
        {
            Jogador j = new Jogador(
                numero,
                posicao,
                nome,
                idade,
                nacionalidade,
                genero,
                numeroSocio,
                contacto
            );

            jogadores.Add(j);
            return j;
        }


        public bool AtualizarJogador(Jogador jogador, byte numero, string posicao)
        {
            jogador.Numero = numero;
            jogador.Posicao = posicao;
            return true;
        }
        public Jogador ProcurarJogadorPorNumeroSocio(int numeroSocio)
        {
            foreach (Jogador j in jogadores)
            {
                if (j.NumeroSocio == numeroSocio)
                    return j;
            }
            return null;
        }

        public IReadOnlyList<Jogador> ListarJogadores()
        {
            return jogadores.AsReadOnly();
        }

        public bool GuardarJogadores(string ficheiro)
        {
            try
            {
                using (FileStream fs = new FileStream(ficheiro, FileMode.Create))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(fs, jogadores);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool LerJogadores(string ficheiro)
        {
            if (!File.Exists(ficheiro))
                return false;

            try
            {
                using (FileStream fs = new FileStream(ficheiro, FileMode.Open))
                {
                    BinaryFormatter bf = new BinaryFormatter();

                    jogadores.Clear();
                    jogadores.AddRange((List<Jogador>)bf.Deserialize(fs));
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