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
    public class Jogador : Pessoa, IComparable<Jogador>
    {
        #region Atributos

        byte numero;
        string posicao;

        #endregion

        #region Construtores

        public Jogador()
        {
            numero = 0;
            posicao = string.Empty;

        }

        public Jogador(byte numero, string posicao, string nome, byte idade, string nacionalidade, string genero, int numeroSocio, int contacto)
                         : base(nome, idade, nacionalidade, genero, numeroSocio, contacto)  // pois estes valores sao herdados de pessao
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
        public int CompareTo(Jogador other)
        {
            if (other == null)
                return 1;

            return this.Numero.CompareTo(other.Numero);
        }

        #endregion


    }
}

