CREATE DATABASE EventDb;
USE EventDb;

---- first Query -----
CREATE TABLE UserInfo(
	[EmailId] VARCHAR(70) PRIMARY KEY ,

	[username] VARCHAR(50) NOT NULL
		CHECK(LEN([username]) BETWEEN 1 AND 50),

	[role] VARCHAR(20) NOT NULL
		CHECK([role] IN('Admin','Participant')),

	[password] VARCHAR(20) NOT NULL
		CHECK(LEN([password])BETWEEN 6 AND 20)
);
SELECT * FROM UserInfo;
----- Second Query -----

CREATE TABLE EventDetails(
	
	[EventId] INT PRIMARY KEY,

	[EventName] VARCHAR(50) NOT NULL
		CHECK(LEN([EventName])between 1 and 50),

	[EventCategory] VARCHAR(50) NOT NULL
		CHECK(LEN([EventCategory])BETWEEN 1 AND 50),

	[EventDate] DATETIME NOT NULL,

	[Description] VARCHAR(100) NULL,

	[Status] VARCHAR(20) NOT NULL
		CHECK([Status] IN('Active','In-Active'))
);
SELECT * FROM EventDetails;

----- Third Query -------

CREATE TABLE SpeakerDetails(
	
	[SpeakerId]INT PRIMARY KEY,

	[SpeakerName] VARCHAR(50) NOT NULL
		CHECK(LEN([SpeakerName]) BETWEEN 1 AND 50)
);
SELECT * FROM SpeakerDetails;
------ Fourth Query -----------

CREATE TABLE SessionInfo(
	
	[sessionId] INT PRIMARY KEY,

	[EventId] INT NOT NULL,

	[SpeakerId] INT NOT NULL,
	
	[SessionTitle] VARCHAR(50) NOT NULL
		CHECK(LEN([SessionTitle])BETWEEN 1 AND 50),

	[Description] VARCHAR(100) NULL,

	[SessionStart] DATETIME NOT NULL,

	[SessionEnd] DATETIME NOT NULL,

	[SessionUrl] VARCHAR(100),

	FOREIGN KEY([EventId]) 
		REFERENCES EventDetails([EventId]),

	FOREIGN KEY([SpeakerId]) 
		REFERENCES SpeakerDetails([SpeakerId])
);
SELECT * FROM SessionInfo;

-------- Fifth Query -----------
CREATE TABLE ParticipantEventDetails(
	id INT PRIMARY KEY,

	ParticipantEmailId VARCHAR(70) NOT NULL UNIQUE,

	EventId INT NOT NULL,

	SessionId INT NOT NULL,

	isAttended BIT
		CHECK(isAttended in('1','0')),
	
	FOREIGN KEY(ParticipantEmailId)
		REFERENCES UserInfo([EmailId]),

	FOREIGN KEY(EventId)
		REFERENCES EventDetails([EventId]),

	FOREIGN KEY(SessionId)
		REFERENCES SessionInfo([sessionid])
);

SELECT * FROM ParticipantEventDetails;