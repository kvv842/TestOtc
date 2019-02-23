namespace OperationsService.Data.Entities.Enums
{
    /// <summary>
    /// Дополнительные действия
    /// </summary>
    public enum DbAdditionalActionsType
    {
        /// <summary>
        /// Отправить данные транзакции в налоговую инспекцию
        /// </summary>
        SendTransactionsTaxOffice = 1,

        /// <summary>
        /// Отправить данные транзакции в банк партнер
        /// </summary>
        SendTransactionPartnerBank = 2,

        /// <summary>
        /// Вывести окно с подтверждением операции
        /// </summary>
        DisplayWindowConfirmingOperation = 3,

        /// <summary>
        /// Отправить смс сообщение
        /// </summary>
        SendSms = 4,

        /// <summary>
        /// Отправить платежные документы
        /// </summary>
        SendBillingDocuments = 5,

        // TODO Если много языков нужно вынести
        /// <summary>
        /// Отправить платежные документы на английском языке
        /// </summary>
        SendBillingDocumentsEn = 6,
    }
}
