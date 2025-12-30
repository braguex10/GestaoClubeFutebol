/*
*	<copyright file="OrcamentoInsuficienteException.cs"
*		Copyright (c) 2025 All Rights Reserved
*	</copyright>
* 	<author>a31508goncalobraga</author>
*	<description></description>
**/


namespace ClubeFutebol.Exceptions
{
    public class OrcamentoInsuficienteException : DominioException
    {
        public OrcamentoInsuficienteException()
            : base("Orçamento insuficiente para a operação.")
        {
        }
    }
}
