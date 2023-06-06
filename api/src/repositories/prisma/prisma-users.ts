import { prisma } from '../../prisma'
import { UserCreateData, Users } from '../user'

export class PrismaUsers implements Users {
    async create(data: UserCreateData) {
        await prisma.user.create({
            data: {
                name: data.name,
                email: data.email,
                password: data.password,
                nick: data.nick,
                gender: data.gender
            }
        })
    }

    async login(email: string): Promise<null | UserCreateData> {
        const userRequest = await prisma.user.findUnique({
            where: {
                email,
            }
        })

        const userReceived: UserCreateData = {
            name: userRequest?.name ?? '',
            email: userRequest?.email ?? '',
            password: userRequest?.password ?? '',
            nick: userRequest?.nick ?? '',
            gender: userRequest?.gender ?? ''
        }

        return userReceived
    }
}