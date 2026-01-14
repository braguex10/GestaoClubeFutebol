/*
*	<copyright file="Jogador.cs"
*		Copyright (c) 2025 All Rights Reserved
*	</copyright>
* 	<author>a31508goncalobraga</author>
*	<description></description>
**/

using System;

namespace ClubeFutebol.BOO.Pessoas
{
    [Serializable]
    /// <summary>
    /// Classe derivada da Classe Pessoa que representa Jogador de uma certa equipa
    /// </summary>
    public class Jogador : Pessoa, IComparable<Jogador>  //necessario para o compareto
    {
        #region Atributos

        byte numero;
        string posicao;

        #endregion

        #region Construtores
        /// <summary>Construtor Vazio</summary>
        public Jogador()
        {
            numero = 0;
            posicao = string.Empty;

        }
        /// <summary>Construtor Completo</summary>
        public Jogador(byte numero, string posicao, string nome, byte idade, string nacionalidade, string genero, int numeroSocio, int contacto)
                         : base(nome, idade, nacionalidade, genero, numeroSocio, contacto)  // pois estes valores sao herdados de pessoa
        {
            Numero = numero;
            Posicao = posicao;
        }

        #endregion

        #region Propriedades

        public byte Numero
        {
            get { return numero; }
            set { numero = value; }

        }

        public string Posicao
        {
            get { return posicao; }
            set { posicao = value; }
        }

        #endregion

        #region Overrides

        public override string ToString()
        {
            return $"{Numero} - {Nome} ({Posicao})";
        }

        #endregion

        #region Metodos
        /// <summary>
        /// Metodo que compara dois jogadores e ordena-os conforme o seu número da camisola
        /// </summary>
        public int CompareTo(Jogador other)
        {
            if (other == null)
                return 1;

            return this.Numero.CompareTo(other.Numero);
        }

        #endregion


    }
}

