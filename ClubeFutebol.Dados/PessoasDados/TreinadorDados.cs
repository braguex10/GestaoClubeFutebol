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

        private readonly List<Treinador> treinadores;   // Lista que armazena todos os treinadores

        #endregion

        #region Construtor

        public TreinadorDados()
        {
            treinadores = new List<Treinador>();   // Inicializa a lista de treinadores
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Criação de um treinador e adiciona à lista de treinadores
        /// </summary>
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

            treinadores.Add(t);  // Adiciona o novo treinador à lista
            return t;  // Retorna o treinador criado
        }

        /// <summary>
        /// Atualiza anos de experiência e tatica do treinador
        /// </summary>
        public bool AtualizarTreinador(
            Treinador treinador,
            short anosExperiencia,
            string tatica)
        {
            treinador.AnosExperiencia = anosExperiencia; 
            treinador.Tatica = tatica;  
            return true;
        }

        /// <summary>
        /// Devolve treinador procurado pelo seu número de sócio
        /// </summary>
        public Treinador ProcurarTreinadorPorNumeroSocio(int numeroSocio)
        {
            // Percorre a lista de treinadores e retorna o treinador que tem o número de sócio fornecido
            foreach (Treinador t in treinadores)
            {
                if (t.NumeroSocio == numeroSocio)
                    return t;  
            }
            return null;  
        }

        /// <summary>
        /// Devolve a lista de treinadores
        /// </summary>
        public IReadOnlyList<Treinador> ListarTreinadores()
        {
            return treinadores.AsReadOnly();   // Retorna uma versão somente leitura da lista de treinadores
        }

        /// <summary>
        /// Guarda em ficheiro os treinadores
        /// </summary>
        public bool GuardarTreinadores(string ficheiro)
        {
            try
            {
                using (FileStream fs = new FileStream(ficheiro, FileMode.Create))   // Cria ou abre o arquivo
                {
                    BinaryFormatter bf = new BinaryFormatter();  // Serializa os dados em binário
                    bf.Serialize(fs, treinadores);  // Grava a lista de treinadores no arquivo
                }
                return true; 
            }
            catch
            {
                return false; 
            }
        }

        /// <summary>
        /// Abre e lê o ficheiro que tem os treinadores
        /// </summary>
        public bool LerTreinadores(string ficheiro)
        {
            if (!File.Exists(ficheiro))  
                return false;  // Retorna false se o arquivo não for encontrado

            try
            {
                using (FileStream fs = new FileStream(ficheiro, FileMode.Open))  // Abre o arquivo para leitura
                {
                    BinaryFormatter bf = new BinaryFormatter();  // Utiliza o BinaryFormatter para desserializar os dados
                    treinadores.Clear();  // Limpa a lista de treinadores antes de carregar os novos dados
                    treinadores.AddRange((List<Treinador>)bf.Deserialize(fs));  // Desserializa os dados e adiciona à lista
                }
                return true;  // Retorna true se a operação foi bem-sucedida
            }
            catch
            {
                return false;  // Retorna false se ocorrer algum erro durante a leitura
            }
        }

        #endregion
    }
}
