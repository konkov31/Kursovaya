USE movie_agregator
GO

CREATE RULE EmailTemplate
AS @value LIKE '%[_a-zA-Z0-9.-]%@%[_a-zA-Z0-9.-]%.[a-zA-Z][a-zA-Z]%'
GO

EXEC sp_bindrule 'EmailTemplate', 'USERS.email'

GO
-- 2 правило
CREATE RULE RatingValue
AS @value BETWEEN 1 AND 10

GO

EXEC sp_bindrule 'RatingValue', 'REVIEWS.rating'

GO

CREATE RULE CheckActorPosition 
AS @value in ('actor','director')
GO

EXEC sp_bindrule 'CheckActorPosition', 'FILM_POSITIONS.position_type'