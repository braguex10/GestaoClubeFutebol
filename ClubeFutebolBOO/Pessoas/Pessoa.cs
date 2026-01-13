/*
*	<copyright file="Pessoa.cs"
*		Copyright (c) 2025 All Rights Reserved
*	</copyright>
* 	<author>a31508goncalobraga</author>
*	<description></description>
**/

using System;

namespace ClubeFutebol.BOO.Pessoas
{
    [Serializable]
    public abstract class Pessoa  //abstrata porque esta serve somente para ser uma base para jogador e treinador
    {

        #region Atributos

        string nome;
        byte idade;
        string nacionalidade;
        string genero;
        int numeroSocio;
        int contacto;

        #endregion

        #region Construtor

        public Pessoa()                 // construtor default
        {
            nome = string.Empty;
            idade = 0;
            nacionalidade = string.Empty;
            genero = string.Empty;
            contacto = 0;
            numeroSocio = 0;
        }

        public Pessoa(string nome, byte idade, string nacionalidade, string genero, int numeroSocio, int contacto)  // construtor que cria o objeto(pessoa)
        {
            Nome = nome;
            Idade = idade;
            Nacionalidade = nacionalidade;
            Genero = genero;
            NumeroSocio = numeroSocio;
            Contacto = contacto;

        }

        #endregion

        #region Propriedades

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        public byte Idade
        {
            get { return idade; }
            set { idade = value; }


        }
        public string Nacionalidade
        {
            get { return nacionalidade; }
            set { nacionalidade = value; }    // nacionalidade pode ser alterada pois é algo possivel, embora invulgar

        }

        public string Genero
        {
            get { return genero; }
            set { genero = value; }                 

        }

        public int NumeroSocio
        {
            get { return numeroSocio; }
            set { numeroSocio = value; }


        }
        public int Contacto
        {
            get { return contacto; }
            set { contacto = value; }
        }
        #endregion

        #region Overrides

        public override string ToString()
        {
            return $"{Nome} ({Idade} anos, {Nacionalidade})";
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Pessoa))
                return false;

            Pessoa other = (Pessoa)obj;
            return this.NumeroSocio == other.NumeroSocio;
        }

        public override int GetHashCode()
        {
            return NumeroSocio.GetHashCode();
        }

        #endregion
    }

}
