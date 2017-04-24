DROP TRIGGER IF EXISTS cal_duration;
DELIMITER $$
CREATE TRIGGER cal_duration 
BEFORE UPDATE ON `loptemp`
FOR EACH ROW 
BEGIN
	DECLARE startTemp DATETIME;
	DECLARE endTemp DATETIME;
	SELECT `StartDate` INTO `startTemp` FROM `lop` WHERE Id =new.Id;
	SELECT `EndDate` INTO `endTemp` FROM `lop` WHERE Id =new.Id;
	
	
	
	
	IF startTemp IS NOT NULL THEN 
		IF endTemp IS NOT NULL THEN 					
			SET new.Duration =  TIMESTAMPDIFF(SECOND,startTemp,endTemp) /60/1440;	
			SET new.LopId = TIMESTAMPDIFF(SECOND,startTemp,endTemp);
			SET new.StartDate =  startTemp;
			SET new.EndDate =  endTemp;	
							
		ELSE		
			SET new.Duration =  TIMESTAMPDIFF(SECOND,startTemp,NOW())/60/1440;
			SET new.LopId = TIMESTAMPDIFF(SECOND,startTemp,NOW());
			SET new.StartDate =  startTemp;
			SET new.EndDate =  NOW();			
		END IF;		
	END IF;
	
END$$

DELIMITER ;