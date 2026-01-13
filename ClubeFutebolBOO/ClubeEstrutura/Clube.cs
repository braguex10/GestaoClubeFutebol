/*
*	<copyright file="Clube.cs"
*		Copyright (c) 2025 All Rights Reserved
*	</copyright>
* 	<author>a31508goncalobraga</author>
*	<description></description>
**/

using System;

namespace ClubeFutebol.BOO.ClubeEstrutura
{
    [Serializable]
    public class Clube : IComparable<Clube> // clubes podem ser comparados
    {
        #region Atributos

        string nome;              
        short anoFundacao;        
        string email;             
        int numeroTelefonico;     
        string pais;              

        public Financas financas;
        #endregion

        #region Construtores

        public Clube()         // construtor default, inicializa os atributos vazios, espaco para futuro preenchimento
        {
            nome = string.Empty;
            anoFundacao = 0;
            email = string.Empty;
            numeroTelefonico = 0;
            pais = string.Empty;
            financas = new Financas();
        }

        public Clube(string nome, short anoFundacao, string email, int numeroTelefonico, string pais)  // construtor com os valores atribuidos
        {
            Nome = nome;
            AnoFundacao = anoFundacao;
            Email = email;
            NumeroTelefonico = numeroTelefonico;
            Pais = pais;
            financas = new Financas();

        }

        #endregion

        #region Propriedades

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        public short AnoFundacao
        {
            get { return anoFundacao; }
            set { anoFundacao = value; }


        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public int NumeroTelefonico
        {
            get { return numeroTelefonico; }
            set { numeroTelefonico = value; }

        }

        public string Pais
        {
            get { return pais; }
            set { pais = value; }
        }
        public Financas Financas
        {
            get { return financas; }
            set { financas = value; }
        }
        #endregion


        #region Metodos

        public int CompareTo(Clube other)  // permite comparar os clubes por nome
        {
            if (other == null)
                return 1;

            return this.Nome.CompareTo(other.Nome);
        }


        #endregion


        #region Overrides

        public override string ToString()  // como o clube aparece em texto
        {
            return $"{Nome} ({Pais}) - Fundado em {AnoFundacao}";
        }

        public override bool Equals(object obj)   // quando os clubes sao iguais
        {
            if (!(obj is Clube))
                return false;

            Clube other = (Clube)obj;
            return this.Nome == other.Nome;
        }

        public override int GetHashCode()  // gera o codigo para depois ser utilizado em colecoes
        {
            return Nome.GetHashCode();
        }

        #endregion
    }
}