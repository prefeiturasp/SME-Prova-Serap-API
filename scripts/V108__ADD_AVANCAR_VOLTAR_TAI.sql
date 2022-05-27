alter table prova add if not exists formato_tai_avancar_sem_responder bool;
alter table prova add if not exists  formato_tai_voltar_item_anterior bool;
update prova set formato_tai_avancar_sem_responder = false, formato_tai_voltar_item_anterior = false;