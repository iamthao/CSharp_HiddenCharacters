DROP FUNCTION IF EXISTS GetSecondDuration;
DELIMITER $$
CREATE FUNCTION GetSecondDuration(requestId INT, milestoneId INT)
  RETURNS DECIMAL
  LANGUAGE SQL -- This element is optional and will be omitted from subsequent examples
BEGIN
	DECLARE startTemp DATETIME;
	DECLARE endTemp DATETIME;
	
	-- Request
	IF milestoneId = 1 OR milestoneId = 8 THEN
		SELECT `ColorRequestStartDate` INTO `startTemp` FROM `request` WHERE Id =requestId;
		SELECT `ColorRequestEndDate` INTO `endTemp` FROM `request` WHERE Id =requestId;				
		IF startTemp IS NOT NULL THEN 
			IF endTemp IS NOT NULL THEN 
				RETURN TIMESTAMPDIFF(SECOND,startTemp,endTemp);							
			ELSE		
				RETURN TIMESTAMPDIFF(SECOND,startTemp,NOW());			
			END IF;		
		END IF;
	END IF;
	
		-- Scheduling
	IF milestoneId = 2 THEN
		SELECT `ColorSchedulingStartDate` INTO `startTemp` FROM `request` WHERE Id =requestId;
		SELECT `ColorSchedulingEndDate` INTO `endTemp` FROM `request` WHERE Id =requestId;				
		IF startTemp IS NOT NULL THEN 
			IF endTemp IS NOT NULL THEN 
				RETURN TIMESTAMPDIFF(SECOND,startTemp,endTemp);							
			ELSE		
				RETURN TIMESTAMPDIFF(SECOND,startTemp,NOW());			
			END IF;		
		END IF;
	END IF;
	
	-- Accessment
	IF milestoneId = 3 THEN
		SELECT `ColorAssessmentStartDate` INTO `startTemp` FROM `request` WHERE Id =requestId;
		SELECT `ColorAssessmentEndDate`INTO `endTemp` FROM `request` WHERE Id =requestId;				
		IF startTemp IS NOT NULL THEN 
			IF endTemp IS NOT NULL THEN 
				RETURN TIMESTAMPDIFF(SECOND,startTemp,endTemp);							
			ELSE		
				RETURN TIMESTAMPDIFF(SECOND,startTemp,NOW());			
			END IF;		
		END IF;
	END IF;
	
	-- QualityControl
	IF milestoneId = 4 THEN
		SELECT `ColorQCStartDate` INTO `startTemp` FROM `request` WHERE Id =requestId;
		SELECT `ColorQCEndDate` INTO `endTemp` FROM `request` WHERE Id =requestId;				
		IF startTemp IS NOT NULL THEN 
			IF endTemp IS NOT NULL THEN 
				RETURN TIMESTAMPDIFF(SECOND,startTemp,endTemp);							
			ELSE		
				RETURN TIMESTAMPDIFF(SECOND,startTemp,NOW());			
			END IF;		
		END IF;
	END IF;
	
	-- ProviderAcceptance
	IF milestoneId = 5 THEN
		SELECT `ColorProviderAcceptanceStartDate` INTO `startTemp` FROM `request` WHERE Id =requestId;
		SELECT `ColorProviderAcceptanceEndDate` INTO `endTemp` FROM `request` WHERE Id =requestId;				
		IF startTemp IS NOT NULL THEN 
			IF endTemp IS NOT NULL THEN 
				RETURN TIMESTAMPDIFF(SECOND,startTemp,endTemp);							
			ELSE		
				RETURN TIMESTAMPDIFF(SECOND,startTemp,NOW());			
			END IF;		
		END IF;
	END IF;
	
	-- PhysicianOrder
	IF milestoneId = 6 THEN
		SELECT `ColorPhysicianOrderStartDate` INTO `startTemp` FROM `request` WHERE Id =requestId;
		SELECT `ColorPhysicianOrderEndDate` INTO `endTemp` FROM `request` WHERE Id =requestId;				
		IF startTemp IS NOT NULL THEN 
			IF endTemp IS NOT NULL THEN 
				RETURN TIMESTAMPDIFF(SECOND,startTemp,endTemp);							
			ELSE		
				RETURN TIMESTAMPDIFF(SECOND,startTemp,NOW());			
			END IF;		
		END IF;
	END IF;
	
	-- PriorAuthorization
	IF milestoneId = 7 THEN
		SELECT `ColorPAStartDate` INTO `startTemp` FROM `request` WHERE Id =requestId;
		SELECT `ColorPAEndDate` INTO `endTemp` FROM `request` WHERE Id =requestId;				
		IF startTemp IS NOT NULL THEN 
			IF endTemp IS NOT NULL THEN 
				RETURN TIMESTAMPDIFF(SECOND,startTemp,endTemp);							
			ELSE		
				RETURN TIMESTAMPDIFF(SECOND,startTemp,NOW());			
			END IF;		
		END IF;
	END IF;
		
	RETURN 0;
END;
$$
DELIMITER ;