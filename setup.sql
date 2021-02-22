USE boisecodeworks;

CREATE TABLE trips
(
  id INT AUTO_INCREMENT,
  days INT,
  dailycharge DECIMAL(7, 2),
  location VARCHAR(255),
  housing VARCHAR(255),

  PRIMARY KEY(id)
)

-- DROP TABLE cruises;

-- CREATE TABLE cruises
-- (
--   id INT AUTO_INCREMENT,
--   days INT,
--   dailycharge DECIMAL(7, 2),
--   location VARCHAR(255),

--   PRIMARY KEY(id)
-- )