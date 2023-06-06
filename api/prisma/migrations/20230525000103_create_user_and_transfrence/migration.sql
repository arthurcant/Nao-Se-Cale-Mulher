-- CreateTable
CREATE TABLE "users" (
    "id" TEXT NOT NULL PRIMARY KEY,
    "name" TEXT NOT NULL,
    "email" TEXT NOT NULL,
    "password" TEXT NOT NULL,
    "patrimony" REAL NOT NULL,
    "salary" REAL NOT NULL
);

-- CreateTable
CREATE TABLE "transference" (
    "id" TEXT NOT NULL PRIMARY KEY,
    "name" TEXT NOT NULL,
    "value" REAL NOT NULL,
    "recurrent" BOOLEAN NOT NULL,
    "emailUser" TEXT NOT NULL,
    "expense" BOOLEAN NOT NULL
);

-- CreateIndex
CREATE UNIQUE INDEX "users_email_key" ON "users"("email");
