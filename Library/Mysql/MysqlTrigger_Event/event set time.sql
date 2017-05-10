SET GLOBAL event_scheduler = ON;
DROP EVENT IF EXISTS set_Time2;

CREATE EVENT set_Time2
    ON SCHEDULE
      EVERY 2 MINUTE
        DO
UPDATE `user` 
SET Time2=NOW() 
WHERE Time1 IS NOT NULL AND Time2IsSet !=  1 ;