export interface UserCreateData {
    name: string
    email: string
    password: string
    nick: string
    gender: string
}

export interface Users {
    create(data: UserCreateData): Promise<void>
    login(email: string): Promise<UserCreateData | null>
}