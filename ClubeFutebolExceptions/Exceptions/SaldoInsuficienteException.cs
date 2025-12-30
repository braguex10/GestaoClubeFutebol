/*
*	<copyright file="SaldoInsuficienteException.cs"
*		Copyright (c) 2025 All Rights Reserved
*	</copyright>
* 	<author>a31508goncalobraga</author>
*	<description></description>
**/

namespace ClubeFutebol.Exceptions
{
    public class SaldoInsuficienteException : DominioException
    {
        public SaldoInsuficienteException()
            : base("Saldo insuficiente para realizar a operação.")
        {
        }
    }
}
