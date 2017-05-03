DROP TRIGGER IF EXISTS cal_duration;
DELIMITER $$
CREATE TRIGGER cal_duration 
BEFORE UPDATE ON `user`
FOR EACH ROW 
BEGIN
	IF new.Time1 IS NOT NULL THEN 
		IF new.Time2 IS NOT NULL THEN 					
			SET new.Duration =  TIMESTAMPDIFF(MINUTE,new.Time1,new.Time2) ;	
			SET new.DurationInt =  TIMESTAMPDIFF(MINUTE,new.Time1,new.Time2) /1440;	
			IF (TIMESTAMPDIFF(MINUTE,new.Time1,new.Time2) /1440 <= 1 ) THEN
				SET new.Color = 'green';
			END IF;	
			IF (TIMESTAMPDIFF(MINUTE,new.Time1,new.Time2) /1440 > 1 AND TIMESTAMPDIFF(MINUTE,new.Time1,new.Time2) /1440 <=2) THEN
				SET new.Color =  'yellow';
			END IF;	
			IF (TIMESTAMPDIFF(MINUTE,new.Time1,new.Time2) /1440 > 2 AND TIMESTAMPDIFF(MINUTE,new.Time1,new.Time2) /1440 <=3) THEN
				SET new.Color =  'red';
			END IF;	
				
		ELSE
			
			SET new.Duration =  TIMESTAMPDIFF(MINUTE,new.Time1,new.Time2) ;	
			SET new.DurationInt =  TIMESTAMPDIFF(MINUTE,new.Time1,new.Time2) /1440;	
			IF (TIMESTAMPDIFF(MINUTE,new.Time1,new.Time2) /1440 <= 1 ) THEN
				SET new.Color = 'green';
			END IF;	
			IF (TIMESTAMPDIFF(MINUTE,new.Time1,new.Time2) /1440 > 1 AND TIMESTAMPDIFF(MINUTE,new.Time1,new.Time2) /1440 <=2) THEN
				SET new.Color =  'yellow';
			END IF;	
			IF (TIMESTAMPDIFF(MINUTE,new.Time1,new.Time2) /1440 > 2 AND TIMESTAMPDIFF(MINUTE,new.Time1,new.Time2) /1440 <=3) THEN
				SET new.Color =  'red';
			END IF;		
		END IF;		
	END IF;
END$$

DELIMITER ;