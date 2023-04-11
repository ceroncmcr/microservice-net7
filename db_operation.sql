create schema db_operation collate utf8mb4_0900_ai_ci;

create table db_operation.Payment
(
    id_transaccion int auto_increment
        primary key,
    id_invoice     int            not null,
    amount         decimal(18, 2) not null,
    date           longtext       null
);
