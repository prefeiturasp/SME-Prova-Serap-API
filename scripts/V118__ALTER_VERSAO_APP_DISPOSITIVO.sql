alter table versao_app_dispositivo ADD COLUMN IF NOT exists dispositivo_id varchar;
ALTER TABLE public.versao_app_dispositivo ALTER COLUMN dispositivo_imei DROP NOT NULL;